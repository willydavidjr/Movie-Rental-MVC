using Emerson1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emerson1.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input correct Customer Name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribeToNewsletter { get; set; }

        //public MembershipType MembershipType { get; set; }

        //[Display(Name = "Membership Types")]
        public byte MembershipTypeId { get; set; }

        //[Display(Name = "Date of Birth")]
        //[Min18YearIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}