using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseManagement.Models
{
    public class CaseNote
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public string CaseNoteBody { get; set; }
        public string CaseNoteType { get; set; }
        public int ParticipantId { get; set; }
        public Participants Staff { get; set; }
        public List<Participants> ClientsInvolved { get; set; }




    }
}