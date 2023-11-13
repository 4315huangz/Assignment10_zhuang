using Bank4Us.BusinessLayer.Core;
using Bank4Us.Common.CanonicalSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank4Us.BusinessLayer.Managers.MortgageApplicantManagement
{

        /// <summary>
        ///   Course Name: MSCS 6360 Enterprise Architecture
        ///   Year: Fall 2023
        ///   Name: Ziwei Huang
        ///   Description: Example implementation of a Business Layer              
        /// </summary>
        /// 
        public interface IMortgageApplicantManager : IActionManager
        {
            MortgageApplicant GetMortgageApplicant(int ApplicantID);

            IEnumerable<MortgageApplicant> GetAllMortgageApplicants();
        }
    }

