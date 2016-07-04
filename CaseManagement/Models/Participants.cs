using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaseManagement.Models
{
    public class Participants
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string MedicalCondition { get; set; }
        public string ContactNumer { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Ethnicity { get; set; }
       
        public string Gender { get; set; }
        public Case Case { get; set; }
        public int? CaseId { get; set; }
        public int? RolesId { get; set; }
        public Roles Role { get; set; }


    }
}