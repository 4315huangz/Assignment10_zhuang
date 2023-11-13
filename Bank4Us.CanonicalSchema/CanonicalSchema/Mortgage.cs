using Bank4Us.Common.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Bank4Us.Common.CanonicalSchema
{
    /// <summary>
    ///   Course Name: COSC 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Ziwei Huang
    ///   Description: The mortgage is managed by one loan officer and owned bu one Mortgage Applicant.                
    /// </summary>
    public class Mortgage : BaseEntity
    {
        [JsonIgnore]
        [Key]
        public int MortgageId { get; set; }

        [MaxLength(255)]
        public string PropertyAddress { get; set; }
        public double LoanAmount { get; set; }
        public int LoanTerm { get; set; }
        public double InterestRate { get; set; }
        public double MonthlyPayment { get; set; }
        [JsonIgnore]
        public int Status { get; set; }
        public void UpdateMortgageStatus(MortgageStatus acStat)
        {
            Status = (int)acStat;
        }

        public enum MortgageStatus
        {
            Approved = 1,
            Reviewing = 2,
            Declined = 3
        }


    }
}
