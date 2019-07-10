using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChurchConnectLite.Core.Entities;
using ChurchConnectLite.Data.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;

namespace ChurchConnectLite.Web.Controllers
{
    public class MainMinistersController : Controller
    {
        private readonly ChurchContext _context;

        public MainMinistersController(ChurchContext context)
        {
            _context = context;
        }

        // GET: MainMinisters
        public async Task<IActionResult> Index()
        {
            var churchContext = _context.MainMinisters.Include(m => m.AppUser);
            return View(await churchContext.ToListAsync());
        }

        // GET: MainMinisters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainMinister = await _context.MainMinisters
                .Include(m => m.AppUser)
                .FirstOrDefaultAsync(m => m.ID.ToString() == id.ToString());
            if (mainMinister == null)
            {
                return NotFound();
            }

            return View(mainMinister);
        }

        // GET: MainMinisters/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["ChurchId"] = new SelectList(_context.Churches, "ID", "ID");
            return View();
        }

        // POST: MainMinisters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationUserId,ChurchId,Name,Position,About,FaceBook,Twitter,InstagramProfile,Email,Phone,PictureUrl,PictureBlobName,DateEntered")]MainMinister mainMinister, IFormFile file)
        {
            if (ModelState.IsValid)
            {

                //set the connection string
                if (file == null)
                {
                    mainMinister.DateEntered = DateTime.Now;

                    _context.Add(mainMinister);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Dashboard", "Churches");
                }
                const string accountName = "imagescode";
                const string key = "8mYGwFLxg7dgknmQFtBtvLrOKPQ7KfVYPjQk37lhuE3AH232omisJGVlIgyCsv5lYqwuLPeqy2y1CzWGDE8H4Q==";

                CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, key), true);

                // Create a blob client.
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                // Get a reference to a container named "my-new-container."
                CloudBlobContainer container = blobClient.GetContainerReference("main-minister-picture");

                //Get a refrence to a blob
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(file.FileName);

                using (var fileStream = file.OpenReadStream())
                {
                    await blockBlob.UploadFromStreamAsync(fileStream);
                }
                var blob = container.GetBlockBlobReference(file.FileName);
                var blobUrl = blob.Uri.AbsoluteUri;

                mainMinister.PictureBlobName = file.FileName;
                mainMinister.PictureUrl = blobUrl;
                mainMinister.DateEntered = DateTime.Now;

                _context.Add(mainMinister);
                await _context.SaveChangesAsync();
                return RedirectToAction("Dashboard","Churches");
            }

            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", mainMinister.ApplicationUserId);
           
            return View(mainMinister);
        }

        // GET: MainMinisters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainMinister = await _context.MainMinisters.FindAsync(id);
            if (mainMinister == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", mainMinister.ApplicationUserId);
            ViewData["ChurchId"] = new SelectList(_context.Churches, "ID", "ID");
            return View(mainMinister);
        }

        // POST: MainMinisters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ApplicationUserId,ChurchId,Name,Position,About,FaceBook,Twitter,InstagramProfile,Email,Phone,PictureUrl,PictureBlobName,DateEntered")] MainMinister mainMinister, IFormFile file)
        {
            if (file == null)
            {
                mainMinister.DateEntered = DateTime.Now;

                _context.Update(mainMinister);
                await _context.SaveChangesAsync();
                return RedirectToAction("Dashboard", "Churches");
            }
            if (id.ToString() != mainMinister.ID.ToString())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    const string accountName = "imagescode";
                    const string key = "8mYGwFLxg7dgknmQFtBtvLrOKPQ7KfVYPjQk37lhuE3AH232omisJGVlIgyCsv5lYqwuLPeqy2y1CzWGDE8H4Q==";

                    CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, key), true);

                    // Create a blob client.
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                    // Get a reference to a container named "my-new-container."
                    CloudBlobContainer container = blobClient.GetContainerReference("main-minister-picture");

                    //Get a refrence to a blob
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(file.FileName);

                    using (var fileStream = file.OpenReadStream())
                    {
                        await blockBlob.UploadFromStreamAsync(fileStream);
                    }
                    var blob = container.GetBlockBlobReference(file.FileName);
                    var blobUrl = blob.Uri.AbsoluteUri;

                    mainMinister.PictureBlobName = file.FileName;
                    mainMinister.PictureUrl = blobUrl;
                    mainMinister.DateEntered = DateTime.Now;

                   
                    _context.Update(mainMinister);
                    await _context.SaveChangesAsync();
               
                   
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainMinisterExists(mainMinister.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Dashboard","Churches");
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", mainMinister.ApplicationUserId);
            return View(mainMinister);
        }

        // GET: MainMinisters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainMinister = await _context.MainMinisters
                .Include(m => m.AppUser)
                .FirstOrDefaultAsync(m => m.ID.ToString() == id.ToString());
            if (mainMinister == null)
            {
                return NotFound();
            }

            return View(mainMinister);
        }

        // POST: MainMinisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mainMinister = await _context.MainMinisters.FindAsync(id);
            _context.MainMinisters.Remove(mainMinister);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainMinisterExists(int id)
        {
            return _context.MainMinisters.Any(e => e.ID.ToString() == id.ToString());
        }
    }
}
