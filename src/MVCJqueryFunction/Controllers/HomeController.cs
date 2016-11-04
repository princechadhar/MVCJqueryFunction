using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using MVCJqueryFunction.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Sakura.AspNetCore;

namespace MVCJqueryFunction.Controllers
{

    public class HomeController : Controller
    {
        assignment2dbContext context = null;
        IHostingEnvironment env = null;
        public HomeController(IHostingEnvironment _env, assignment2dbContext _context)
        {
            env = _env;
            context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Categorytbl C)
        {
            C.CreatedDate = DateTime.Today;
            C.ModifiedDate = DateTime.Today;
            context.Categorytbl.Add(C);
            context.SaveChanges();

            ViewBag.message = "data inserted";
            return View();
        }

        [HttpGet]
        public IActionResult AddSubcategory()
        {
            IList<Categorytbl> SL = context.Categorytbl.ToList<Categorytbl>();
            ViewBag.SL = SL;
            return View();
        }

        [HttpPost]
        public IActionResult AddSubCategory(Subcategorytbl SC)
        {
            SC.CreatedDate = DateTime.Today;
            SC.ModifiedDate = DateTime.Today;
            context.Subcategorytbl.Add(SC);
            context.SaveChanges();
            ViewBag.message = "data inserted";
            return RedirectToAction("AddSubcategory");
        }

        [HttpGet]
        public IActionResult AddProduct(int OSL)
        {
            IList<Categorytbl> SL1 = context.Categorytbl.ToList<Categorytbl>();
            ViewBag.SL1 = SL1;

            IList<Subcategorytbl> SL2 = context.Subcategorytbl/*.Where(m=>m.ParentId==OSL)*/.ToList<Subcategorytbl>();
            ViewBag.SL2 = SL2;

            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Producttbl P)
        {
            foreach (var file in Request.Form.Files)
            {
                var name = file.Name;
                var ext = System.IO.Path.GetExtension(file.FileName);
                var filename = DateTime.Now.ToString("ddMMyyyyhhmmss") + ext;

                FileStream fs = new FileStream(env.WebRootPath + "/UploadedData/pps/" + filename, FileMode.Create);
                file.CopyTo(fs);
                fs.Close();
                P.PrductImage = filename;
            }

            P.CreatedDate = DateTime.Today;
            P.ModifiedDate = DateTime.Today;
            context.Producttbl.Add(P);
            context.SaveChanges();
            return RedirectToAction("AddProduct");
        }


        public IActionResult ProductsChanges(Categorytbl c)
        {

            IList<Producttbl> Products = context.Producttbl.Where(m => m.Id > 1002).ToList<Producttbl>();
            return View(Products);
        }
        public string DeleteProduct(int ProductID)
        {
            Producttbl S = new Producttbl();
            S.Id = ProductID;
            try
            {
                context.Producttbl.Remove(S);
                context.SaveChanges();
                return "DONE";
            }
            catch (Exception ex)
            {

            }
            //for http requests only
            //return RedirectToAction("AllStudents");
            return "ERROR";
        }
        public FileResult downloadfile(string filepath)
        {
            string ext = System.IO.Path.GetExtension(filepath);
            return File("/UploadedData/pps/" + filepath, System.Net.Mime.MediaTypeNames.Application.Octet, "download" + ext);
        }


        public ActionResult ProductSearch()
        {
            IList<Producttbl> SL = context.Producttbl.ToList<Producttbl>();
            ViewBag.SL = SL;


            return View();
        }
        public string ProductSearchAjax(int ProductID)
        {
            Producttbl P = context.Producttbl.FirstOrDefault<Producttbl>(m => m.Id == ProductID);

            string data = "";

            data += "<table class='table table-striped'>";
            data += "<tr>";

            data += "<td>";
            data += P.Id;
            data += "</td>";

            data += "<td>";
            data += P.ProductName;
            data += "</td>";

            data += "<td>";
            data += P.ProductDescription;
            data += "</td>";

            data += "<td>";
            data += P.ProductPrice;
            data += "</td>";

            data += "<td>";
            data += "<img src=/UploadedData/pps/" + P.PrductImage + "  style='width: 40%; height:100px' class='img-circle'/>";
            data += "</td>";

            data += "</tr>";
            data += "</table>";

            return data;

        }

    }
}


