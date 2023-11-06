using Bank4Us.Common.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank4Us.Common.CanonicalSchema
{
    /// <summary>
    ///   Course Name: COSC 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Ziwei Huang
    ///   Description: The Credit Report belongs to the Mortgage Applicant on a one-to-one association.                
    /// </summary>
    public class CreditReport : BaseEntity
    {
        [Key]
        public int ReportID { get; set; }
        
        public DateTime ReportDate { get; set; }
        public int CreditScore { get; set; }
        public double OutstandingDebt { get; set; }
    }
}
