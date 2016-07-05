using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseManagement.Models
{
    public class Family
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Participants> FamilyMembers { get; set; }

    }
}