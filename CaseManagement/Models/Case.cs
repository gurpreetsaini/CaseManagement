﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseManagement.Models
{
    public class Case
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public int ParticipantsId { get; set; }
        public List<Participants> Participants { get; set; }
        public int CaseNotesId { get; set; }
        public List<CaseNote> CaseNotes { get; set; }
        public DateTime DateOpened { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateClosed { get; set; }
        public Participants KeyWorker { get; set; }


    }
}