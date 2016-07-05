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


            return View("ParticipantForm", partipant);
        }


        [HttpPost]
        public ActionResult Save(Participants participant)
        {

            //if (!ModelState.IsValid)
            //    return HttpNotFound("error in validation");

            if (participant.Id == 0)
            {
                _context.Participants.Add(participant);

            }
            else
            {
                var participantInDb = _context.Participants.Single(m => m.Id == participant.Id);
                participantInDb.Name = participant.Name;
                participantInDb.BirthDate = participant.BirthDate;
                participantInDb.Address = participant.Address;
                participantInDb.Gender = participant.Gender;
            }


            _context.SaveChanges();
            return RedirectToAction("Index", "Participants");

            
        }

        public ActionResult Create()
        {
            var participants = _context.Participants.ToList();


            return View("ParticipantForm");
        }

        public ActionResult CreateNewCasenote()
        {
            return View("NewCasenote");
        }

    }
}