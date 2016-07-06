using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseManagement.Models.ViewModels
{
    public class CaseParticpantCasenoteViewModel
    {
        public List<Case> Cases { get; set; }
        public List<Participants> Participant { get; set; }
        public List<CaseNote> CaseNotes { get; set; }



    }
}