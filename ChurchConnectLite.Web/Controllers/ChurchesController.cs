using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChurchConnectLite.Core.Entities;
using ChurchConnectLite.Data.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.AspNetCore.Authorization;

namespace ChurchConnectLite.Web.Controllers
{
    
    public class ChurchesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ChurchContext _context;

        public ChurchesController(ChurchContext context, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Churches
        public async Task<IActionResult> Index(int? id)
        {

            if (id == null)
            {
                var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                var churchContext = await _context.Churches
                    .Include(m => m.MainMinisters)
                    .Include(c => c.Gallery)
                    .Include(c => c.Denominations).Include(c=>c.Ministers)
                    .FirstOrDefaultAsync(m => m.ID == id);
                    //.FirstOrDefaultAsync(m => m.ApplicationUserId == currentUser.Id);
                
                if (churchContext == null)
                {
                    return NotFound();
                }
              
                return View(churchContext);
            }
            else
            {
                var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                var churchContext = await _context.Churches
                    .Include(m => m.MainMinisters)
                    .Include(c => c.Gallery)
                    .Include(c => c.Denominations).Include(c => c.Ministers)
                                        .FirstOrDefaultAsync(m => m.ID == id);

                //.FirstOrDefaultAsync(m => m.ApplicationUserId == currentUser.Id);

                if (churchContext == null)
                {
                    return NotFound();
                }
                churchContext.Visitor  += 1;
                _context.SaveChanges();
                return View(churchContext);
            }

        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddPaystack([FromBody]Donation donation)
        {
            _context.Donations.Add(donation);
            var status = _context.SaveChangesAsync();
            
           
            return Json(status);
        }


        // GET: Churches/Dashboard/5
        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (currentUser == null)
            {
                return Challenge();
            }
           

            var church = await _context.Churches.Include(c => c.Denominations).Include(c => c.Gallery).Include(c=>c.Ministers).Include(c=>c.MainMinisters).Include(c=>c.Donations)
                .FirstOrDefaultAsync(m => m.ApplicationUserId == currentUser.Id);
            if (church == null)
            {
                return NotFound();
            }
            ViewData["DonationSum"] = church.Donations.Sum(m => m.Amount);
            ViewData["DonationCount"] = church.Donations.Count();
            return View(church);
        }




        // GET: Churches/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser!=null)
            {
                var church = _context.Churches.SingleOrDefault(x => x.ApplicationUserId == currentUser.Id);
                return Redirect($"/Churches/Edit/{church.ID}");
            }

            if (currentUser == null)
            {
                return Challenge();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "ID", "ID");
            ViewData["DenominationId"] = new SelectList(_context.Denominations, "ID", "ID");
            ViewData["StateId"] = new SelectList(_context.States, "ID", "ID");
            return View();
        }

        // POST: Churches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ID,DenominationId,State,Country,ApplicationUserId, Name,YearFounded,About,Email,Phone1,Phone2,WorshipDays,Website,LogoUrl,Address,OnlineServiceUrl,Account,AccountName,AccountNumber,Facebook,Twitter,Instagram")] Church church, IFormFile file)
        {

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    church.LogoBlobName = file.FileName;
                }

                //set the connection string
                const string accountName = "imagescode";
                const string key = "8mYGwFLxg7dgknmQFtBtvLrOKPQ7KfVYPjQk37lhuE3AH232omisJGVlIgyCsv5lYqwuLPeqy2y1CzWGDE8H4Q==";

                CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, key), true);

                // Create a blob client.
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                // Get a reference to a container named "my-new-container."
                CloudBlobContainer container = blobClient.GetContainerReference("main-minister-picture");

                //Get a refrence to a blob

                if (file != null)
                {
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(file.FileName);

                    using (var fileStream = file.OpenReadStream())
                    {
                        await blockBlob.UploadFromStreamAsync(fileStream);
                    }
                    var blob = container.GetBlockBlobReference(file.FileName);
                    var blobUrl = blob.Uri.AbsoluteUri;

                    church.LogoBlobName = file.FileName;
                    church.LogoUrl = blobUrl;
                }


                

                church.ApplicationUserId = currentUser.Id;
                _context.Add(church);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Dashboard));
            }
            
            ViewData["DenominationId"] = new SelectList(_context.Denominations, "ID", "ID", church.DenominationId);
        
            return View(church);
        }

        // GET: Churches/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var church = await _context.Churches.FindAsync(id);
            if (church == null)
            {
                return NotFound();
            }
          
            ViewData["DenominationId"] = new SelectList(_context.Denominations, "ID", "Name");
           
            return View(church);
        }

        // POST: Churches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DenominationId,YearFounded,BankName,State,Country,State,Visitor,City,Name,Year,About,Email,Phone1,Phone2,WorshipDays,Website,LogoUrl,Address,OnlineServiceUrl,Account,AccountName,AccountNumber,Facebook,Twitter,Instagram")] Church church, IFormFile file)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (id != church.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (file == null)
                    {
                        church.ApplicationUserId = currentUser.Id;
                        _context.Update(church);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Dashboard", "Churches");
                    }

                    church.LogoBlobName = file.FileName;


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

                    church.LogoUrl = blobUrl;

                    church.ApplicationUserId = currentUser.Id;
                    _context.Update(church);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChurchExists(church.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Dashboard", "Churches");
            }
           
            ViewData["DenominationId"] = new SelectList(_context.Denominations, "ID", "ID", church.DenominationId);
           
            return View(church);
        }

        // GET: Churches/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var church = await _context.Churches
                .Include(c => c.Country)
                .Include(c => c.Denominations)
                .Include(c => c.State)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (church == null)
            {
                return NotFound();
            }

            return View(church);
        }

        // POST: Churches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var church = await _context.Churches.FindAsync(id);
            _context.Churches.Remove(church);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChurchExists(int id)
        {
            return _context.Churches.Any(e => e.ID == id);
        }
    }
}
