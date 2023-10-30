using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank4Us.CanonicalSchema
{
    public class Mortgage
    {
        /// <summary>
        ///   Course Name: COSC 6360 Enterprise Architecture
        ///   Year: Fall 2023
        ///   Name: Ziwei Huang
        ///   Description: The mortgage is managed by one loan officer and owned bu one Mortgage Applicant.                
        /// </summary>
        public int MortgageId { get; set; }
        public string PropertyAddress { get; set; }
        public double LoanAmount { get; set; }
        public int LoanTerm { get; set; }
        public double InterestRate { get; set; }
        public double MonthlyPayment { get; set; }
        public Boolean ApproveStatus { get; set; }
        
        

    }
}
