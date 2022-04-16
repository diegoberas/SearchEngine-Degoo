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
        public ActionResult Search(string keyword, int? page)
        {
            var geturls = _context.Links.Where(k => DegooContext.SoundsLike(k.Url) == DegooContext.SoundsLike(keyword)).OrderBy(k => k.Id).ToList();
            //int pageNumber = page ?? 1;
            //int pageSize = 3;
            //var links = geturls.OrderBy(k => k.Id).ToPagedList(pageNumber, pageSize);


            //var links = geturls.ToPagedList(page ?? 1, 3);

            if (string.IsNullOrEmpty(keyword))
            {
                return RedirectToAction("Index");
            }

            if (geturls == null)
            {
                return HttpNotFound();
            }

            // Pagination
            //if (page > 0)
            //{
            //    page = page;
            //}
            //else
            //{
            //    page = 1; //page default 1
            //}
            //int limit = 5; //show 5 urls 
            //int start = (int)(page - 1) * limit;
            //int totalUrl = geturls.Count();
            //ViewBag.totalUrl = totalUrl;
            //ViewBag.pageCurrent = page;
            //int numberPage = (totalUrl / limit);
            //ViewBag.numberPage = numberPage;
            //var dataUrl = geturls.Where(k => DegooContext.SoundsLike(k.Url) == DegooContext.SoundsLike(keyword)).OrderBy(k => k.Id)
            //    .Skip(start)
            //    .Take(limit);

            return View(geturls);
        }
    }
}