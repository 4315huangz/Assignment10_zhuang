
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
    ///   Description: The Loan Officer manages multiple Mortgages (One-to-Many) and 
    ///   serves multiples Mortgage Applicants (One-to-Many).                
    /// </summary>
    public class LoanOfficer : BaseEntity
    {
        //[JsonIgnore]
        [Key]
        public int OfficerId { get; set; }

        public Person Person { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }
      
        public List<Mortgage> Mortgages { get; set; }
       
    }
}
