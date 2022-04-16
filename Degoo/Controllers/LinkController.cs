using Degoo.Models;
using Degoo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using System.Threading.Tasks;

namespace Degoo.Controllers
{
    public class LinkController : Controller
    {
         private DegooContext _context;

        public LinkController()
        {
            _context = new DegooContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //GET: Link
        public ActionResult Index()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Index(string keyword)
        {
            var findUrl = _context.Links.Where(k => DegooContext.SoundsLike(k.Url) == DegooContext.SoundsLike(keyword));

            return RedirectToAction("Search", findUrl);
        }

         //GET: Link
        public ActionResult All(int? page)
        {
                var getall = _context.Links.ToList();
                int pageNumber = page ?? 1;
                int pageSize = 10;
            
                var links = getall.OrderBy(k => k.Id).ToPagedList(pageNumber, pageSize);

                return View(links);
        }

        //GET: Link
        public ActionResult Search(string keyword)
        {
            var geturls = _context.Links.Where(k => DegooContext.SoundsLike(k.Url) == DegooContext.SoundsLike(keyword)).OrderBy(k => k.Id).ToList();
                
            if (string.IsNullOrEmpty(keyword))
            {
                return RedirectToAction("All", "Link");
            }

            if (geturls == null)
            {
                return HttpNotFound();
            }

            return View(geturls);

            // Pagination
            //if (page > 0)
            //{
            //    page = page;
            //}
            //else
            //{
            //    page = 1; //page default 1
            //}
            //int limit = 1; //show 5 urls 
            //int start = (int)(page - 1) * limit;
            //int totalUrl = geturls.Count();
            //ViewBag.totalUrl = totalUrl;
            //ViewBag.pageCurrent = page;
            //int numberPage = (totalUrl / limit);
            //ViewBag.numberPage = numberPage;
            //var dataUrl = geturls.OrderBy(k => k.Id)
            //    .Skip(start)
            //    .Take(limit);

            
        }
    }
}