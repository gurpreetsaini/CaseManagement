using CaseManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseManagement.Controllers
{
    public class CaseNoteController : Controller
    {
        // GET: CaseNote


        private ApplicationDbContext _context;
        public CaseNoteController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var casenotes = _context.CaseNote.ToList();
            return View(casenotes);
        }



        public ActionResult NewCaseNote()
        {
            return View();
        }
        [HttpPost]
       
        public ActionResult Save(CaseNote casenote)
        {
            _context.CaseNote.Add(casenote);
            _context.SaveChanges();

            return RedirectToAction("Index", "CaseNote" );
        }

        public ActionResult Details(int Id)
        {

            var casenote = _context.CaseNote.SingleOrDefault(c => c.Id == Id);


            return View("NewCaseNote", casenote);
        }


    }
}