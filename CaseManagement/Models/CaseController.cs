using CaseManagement.Models;
using CaseManagement.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseManagement.Models
{

    public class CaseController : Controller
    {

        private ApplicationDbContext _context;

        public CaseController()
        {
            _context = new ApplicationDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Case
        public ActionResult Index()
        {
            var viewModel = new CaseParticpantCasenoteViewModel
            {
                CaseNotes = _context.CaseNote.ToList(),
                Cases = _context.Case.ToList(),
                Participant = _context.Participants.ToList()


            };

         

            return View(viewModel);
        }





    }




    



}