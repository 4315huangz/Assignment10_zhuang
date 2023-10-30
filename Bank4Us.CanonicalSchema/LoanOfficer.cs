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
    ///   Description: The Loan Officer manages multiple Mortgages (One-to-Many) and 
    ///   serves multiples Mortgage Applicants (One-to-Many).                
    /// </summary>
    public class LoanOfficer: Person
    {
        public int OfficerId { get; set; }
        public string Title { get; set; }
        public List<MortgageApplicant>  MortgageApplicants { get; set; }
        public List<Mortgage> Mortgages { get; set; }
    }
}
