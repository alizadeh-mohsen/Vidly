﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public MembershipType MembershipType { get; set; }
        
        public byte MembershipTypeId { get; set; }

        [AgeCheckValidation]
        public DateTime Birthday { get; set; }

        public byte DiscountRate { get; set; }
    }
}