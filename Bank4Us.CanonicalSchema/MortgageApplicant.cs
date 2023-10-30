using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank4Us.CanonicalSchema
{
    /// <summary>
    ///   Course Name: COSC 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Ziwei Huang
    ///   Description: The Mortgage applicant may have one or more mortage applications undergoing (one-to-mane)
    ///   and each applicant has one loan officer to work with (one-to-one).                
    /// </summary>
    public class MortgageApplicant: Person
    {
        public int ApplicantID { get; set; }
        public LoanOfficer LoanOfficer { get; set; }
        public CreditReport Report { get; set; }
        public List<Mortgage> Mortgages { get; set; }

    }
}
