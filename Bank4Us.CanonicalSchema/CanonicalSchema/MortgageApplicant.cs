
using Bank4Us.Common.Core;
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
    ///   Description: The Mortgage applicant may have one or more mortage applications undergoing (one-to-mane)
    ///   and each applicant has one loan officer to work with (one-to-one).                
    /// </summary>
    public class MortgageApplicant : BaseEntity
    {
        [Key]
        public int ApplicantID { get; set; }
       
        public Person Person { get; set; }

        public CreditReport CreditReport { get; set; }

        public List<Mortgage> Mortgages { get; set; }

    }
}
