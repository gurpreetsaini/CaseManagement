using CaseManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseManagement.Controllers
{
    public class ParticipantsController : Controller
    {
        // GET: Participants

        private ApplicationDbContext _context;

        public ParticipantsController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {


            var participants = _context.Participants.ToList();

            if (participants == null)
                return HttpNotFound();

            return View(participants);
        }


        public ActionResult Details(int Id)
        {

            var partipant = _context.Participants.SingleOrDefault(c => c.Id == Id);


            return View("Details", partipant);
        }


        [HttpPost]
        public ActionResult Save(Participants participant)
        {

            if (!ModelState.IsValid)
                return HttpNotFound();

            var movieInDb = _context.Participants.Single(m => m.Id == participant.Id);
            movieInDb.Name = participant.Name;
            movieInDb.BirthDate = participant.BirthDate;
            movieInDb.Address = participant.Address;
            movieInDb.Gender = participant.Gender;



            _context.SaveChanges();
            return RedirectToAction("Index", "Participants");

            
        }



    }
}