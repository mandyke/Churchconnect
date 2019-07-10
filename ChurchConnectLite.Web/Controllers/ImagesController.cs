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
    public class ImagesController : Controller
    {
        private readonly ChurchContext _context;

        public ImagesController(ChurchContext context)
        {
            _context = context;
        }

        // GET: Images
        public IActionResult Index()
        {
            return View(_context.Images.Include(m => m.Church).ToList());
        }


        // GET: Images/Create
        public IActionResult Create(int? Id)
        {
            return View();
        }
        // POST: Images/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IEnumerable<IFormFile> File, int Id)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in File)
                {
                    //set the connection string
                    const string accountName = "imagescode";
                    const string key = "8mYGwFLxg7dgknmQFtBtvLrOKPQ7KfVYPjQk37lhuE3AH232omisJGVlIgyCsv5lYqwuLPeqy2y1CzWGDE8H4Q==";

                    CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, key), true);

                    // Create a blob client.
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                    // Get a reference to a container named "my-new-container."
                    CloudBlobContainer container = blobClient.GetContainerReference("church-connect-gallery-images");

                    //Get a refrence to a blob
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(file.FileName);

                    using (var fileStream = file.OpenReadStream())
                    {
                        await blockBlob.UploadFromStreamAsync(fileStream);
                    }
                    var blob = container.GetBlockBlobReference(file.FileName);
                    var blobUrl = blob.Uri.AbsoluteUri;
                    var pitureName = file.FileName;
                    var toAddToChurchGallery = new Image()
                    {
                        PictureUrl = blobUrl,
                        ChurchId = Id,
                        FileName = pitureName
                    };
                    _context.Images.Add(toAddToChurchGallery);
                    await _context.SaveChangesAsync();
                }
                return View();
            }
            return View();
        }
           
        

        // GET: Images/Edit/5
        

        // POST: Images/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       

        // GET: Images/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var images = _context.Images
               .Where(m => m.ID == id).SingleOrDefault();
            if (images == null)
            {
                return NotFound();
            }

            return View(images);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Image = await _context.Images.FindAsync(id);

            //set the connection string
            const string accountName = "imagescode";
            const string key = "8mYGwFLxg7dgknmQFtBtvLrOKPQ7KfVYPjQk37lhuE3AH232omisJGVlIgyCsv5lYqwuLPeqy2y1CzWGDE8H4Q==";

            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, key), true);

            // Create a blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Get a reference to a container named "my-new-container."
            CloudBlobContainer container = blobClient.GetContainerReference("church-connect-gallery-images");

            //Get a refrence to a blob
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(Image.FileName);
            await blockBlob.DeleteAsync();

            _context.Images.Remove(Image);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

        
    