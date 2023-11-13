using Bank4Us.Common.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank4Us.Common.CanonicalSchema
{
    /// <summary>
    ///   Course Name: COSC 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Ziwei Huang
    ///   Description: The Person is generic type to be inherited by MortgageApplicant and LoanOfficer and shares 
    ///   common attributes with the derived classes.
    /// </summary>
    public class Person : BaseEntity
    {
        [JsonIgnore]
        [Key]
        public int Id { get; set; }
        public String SSN { get; set; }
        [MaxLength(255)]
        public string FirstName { get; set; }
        [MaxLength(255)]
        public string LastName { get; set; }
        [MaxLength(255)]
        public string Address { get; set; }
        [MaxLength(25)]
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }
        [MaxLength(255)]
        public string EmailAddress { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

    }
}
