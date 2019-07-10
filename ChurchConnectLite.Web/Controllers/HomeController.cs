using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChurchConnectLite.Web.Models;
using ChurchConnectLite.Data.Data;
using ChurchConnectLite.Core.Entities;
using ChurchConnectLite.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChurchConnectLite.Web.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly ChurchContext _context;
        public HomeController(ChurchContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(
            string currentFilter,
            string searchString,
            int? pageNumber)
        {

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var featuredChurch = from s in _context.Churches.Include(m => m.Denominations)
                                 select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                featuredChurch = featuredChurch.Where(s => s.Name.Contains(searchString)
                                       || s.LogoBlobName.Contains(searchString));
            }

            ViewData["DenominationId"] = new SelectList(_context.Denominations, "ID", "Name");

            int pageSize = 3;
            return View(await PaginatedList<Church>.CreateAsync(featuredChurch.AsNoTracking(), pageNumber ?? 1, pageSize));

            //return View(await featuredDemonination.AsNoTracking().ToListAsync());
        }

        [HttpPost]
        public IActionResult PopulateSearchInPage(string searchString)
        {


            if (!String.IsNullOrEmpty(searchString))
            {
            var searchresult = _context.Churches.Where(x => x.Name.Contains(searchString)).Include(x => x.Denominations).ToList();
                if (searchresult !=null)
                {
                    ViewBag.churchList = searchresult;
                    return PartialView("DisplaySearchResult");
                }
                return View();
               
            }

            return RedirectToAction("Home");
        }

        public IActionResult PopulateSortInPageForChurchSize(string searchString)
        {

            //var Churches = from s in _context.Churches.Include(m => m.Denominations).Where(m => m.ChurchSize.Name == searchString)
                           //select s;

            //if (!String.IsNullOrEmpty(searchString))
            //{

            //    Churches = Churches.Where(s => s.Name.Contains(searchString)
            //                           || s.OnlineServiceUrl.Contains(searchString));
            //}

            //ViewBag.churchList = Churches;
            return PartialView("DisplaySearchResult");
        }

        public IActionResult PopulateSortInPageForDenomination(int searchString)
        {

            var Churches = from s in _context.Churches.Include(m => m.Denominations).Where(m => m.Denominations.ID == searchString)
                           select s;

            //if (!String.IsNullOrEmpty(searchString))
            //{

            //    Churches = Churches.Where(s => s.Name.Contains(searchString)
            //                           || s.OnlineServiceUrl.Contains(searchString));
            //}

            ViewBag.churchList = Churches;
            return PartialView("DisplaySearchResult");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
