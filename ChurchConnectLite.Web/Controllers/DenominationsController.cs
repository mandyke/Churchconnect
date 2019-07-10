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

namespace ChurchConnectLite.Web.Controllers
{
    public class DenominationsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ChurchContext _context;

        public DenominationsController(ChurchContext context, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Denominations
        public async Task<IActionResult> Index(int Id, string currentFilter, string searchString, int? pageNumber)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var ChurchByDenomination = _context.Churches.Where(m => m.DenominationId == Id).Include(m =>m.Denominations).Select(m => m);

            if (!String.IsNullOrEmpty(searchString))
            {
                ChurchByDenomination = ChurchByDenomination.Where(s => s.Name.Contains(searchString)
                                       || s.OnlineServiceUrl.Contains(searchString));
            }

            if (ChurchByDenomination == null)
            {
                return NotFound();
            }

            int pageSize = 3;
            return View(await PaginatedList<Church>.CreateAsync(ChurchByDenomination.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        //public async Task<IActionResult> Index(int? id)
        //{
        //    if (id==null)
        //    {
        //        return NotFound();
        //    }
        //    var churchContext = _context.Churches.Where(c => c.DenominationId == id);


        //    return View(await churchContext.ToListAsync());
        //}

        // GET: Denominations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denomination = await _context.Denominations
                .Include(d => d.AppUser)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (denomination == null)
            {
                return NotFound();
            }

            return View(denomination);
        }

        // GET: Denominations/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Denominations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ApplicationUserId,Name,Logo,LogoBlobName,DateEntered")] Denomination denomination, IFormFile file)
        {
            if (ModelState.IsValid)
            {

                if (file == null)
                {
                    _context.Add(denomination);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Dashboard", "Churches");   
                }

                //set the connection string
                const string accountName = "imagescode";
                const string key = "8mYGwFLxg7dgknmQFtBtvLrOKPQ7KfVYPjQk37lhuE3AH232omisJGVlIgyCsv5lYqwuLPeqy2y1CzWGDE8H4Q==";

                CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, key), true);

                // Create a blob client.
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                // Get a reference to a container named "my-new-container."
                CloudBlobContainer container = blobClient.GetContainerReference("denomination-logo");

                //Get a refrence to a blob
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(file.FileName);

                using (var fileStream = file.OpenReadStream())
                {
                    await blockBlob.UploadFromStreamAsync(fileStream);
                }
                var blob = container.GetBlockBlobReference(file.FileName);
                var blobUrl = blob.Uri.AbsoluteUri;

                denomination.LogoBlobName = file.FileName;
                denomination.Logo = blobUrl;



                _context.Add(denomination);
                await _context.SaveChangesAsync();
                return RedirectToAction("Dashboard", "Churches");
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", denomination.ApplicationUserId);
            return View(denomination);
        }

        // GET: Denominations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denomination = await _context.Denominations.FindAsync(id);
            if (denomination == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", denomination.ApplicationUserId);
            return View(denomination);
        }

        // POST: Denominations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ApplicationUserId,Name,YearFounded,BankName,Logo,LogoBlobName")] Denomination denomination)
        {
            if (id != denomination.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(denomination);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DenominationExists(denomination.ID))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", denomination.ApplicationUserId);
            return View(denomination);
        }
       
        // GET: Denominations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denomination = await _context.Denominations
                .Include(d => d.AppUser)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (denomination == null)
            {
                return NotFound();
            }

            return View(denomination);
        }

        // POST: Denominations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var denomination = await _context.Denominations.FindAsync(id);
            _context.Denominations.Remove(denomination);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DenominationExists(int id)
        {
            return _context.Denominations.Any(e => e.ID == id);
        }
    }
}
