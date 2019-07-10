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
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.AspNetCore.Identity;

namespace ChurchConnectLite.Web.Controllers
{
    public class MinistersController : Controller
    {
        private readonly ChurchContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MinistersController(ChurchContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Ministers
        public async Task<IActionResult> Index()
        {
            var churchContext = _context.Ministers.Include(m => m.AppUser).Include(m => m.Church);
            return View(await churchContext.ToListAsync());
        }

        // GET: Ministers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minister = await _context.Ministers
                .Include(m => m.AppUser)
                .Include(m => m.Church)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (minister == null)
            {
                return NotFound();
            }

            return View(minister);
        }

        // GET: Ministers/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["ChurchId"] = new SelectList(_context.Churches, "ID", "ID");
            return View();
        }

        // POST: Ministers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ApplicationUserId,Name,About,FaceBook,Twitter,InstagramProfile,Email,Phone,PictureUrl,DateEntered")] Minister minister, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //set the connction string
                const string accountName = "imagescode";
                const string key = "8mYGwFLxg7dgknmQFtBtvLrOKPQ7KfVYPjQk37lhuE3AH232omisJGVlIgyCsv5lYqwuLPeqy2y1CzWGDE8H4Q==";

                CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, key), true);

                // Create a blob client.
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                // Get a reference to a container named "my-new-container
                CloudBlobContainer container = blobClient.GetContainerReference("minister-picture");

                //Get a reference to a blob
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(file.FileName);

                using (var fileStream = file.OpenReadStream())
                {
                    await blockBlob.UploadFromStreamAsync(fileStream);
                }

                var blob = container.GetBlockBlobReference(file.FileName);
                var blobUrl = blob.Uri.AbsoluteUri;
                var church = await _userManager.GetUserAsync(HttpContext.User);
                var churchID = _context.Churches.SingleOrDefault(x => x.ApplicationUserId == church.Id.ToString()).ID;
                minister.ChurchId = churchID;
                minister.PictureBlobName = file.FileName;
                minister.PictureUrl = blobUrl;
                minister.DateEntered = DateTime.Now;

                _context.Add(minister);
                await _context.SaveChangesAsync();
                return RedirectToAction("Dashboard", "Churches" );
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", minister.ApplicationUserId);
            ViewData["ChurchId"] = new SelectList(_context.Churches, "ID", "ID", minister.ChurchId);
            return View(minister);
        }

        // GET: Ministers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minister = await _context.Ministers.FindAsync(id);
            if (minister == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", minister.ApplicationUserId);
            ViewData["ChurchId"] = new SelectList(_context.Churches, "ID", "ID", minister.ChurchId);
            return View(minister);
        }

        // POST: Ministers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ApplicationUserId,ChurchId,Name,About,FaceBook,Twitter,InstagramProfile,Email,Phone,PictureUrl,DateEntered")] Minister minister)
        {
            if (id != minister.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(minister);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MinisterExists(minister.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", minister.ApplicationUserId);
            ViewData["ChurchId"] = new SelectList(_context.Churches, "ID", "ID", minister.ChurchId);
            return View(minister);
        }

        // GET: Ministers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minister = await _context.Ministers
                .Include(m => m.AppUser)
                .Include(m => m.Church)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (minister == null)
            {
                return NotFound();
            }

            return View(minister);
        }

        // POST: Ministers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var minister = await _context.Ministers.FindAsync(id);
            _context.Ministers.Remove(minister);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MinisterExists(int id)
        {
            return _context.Ministers.Any(e => e.ID == id);
        }
    }
}
