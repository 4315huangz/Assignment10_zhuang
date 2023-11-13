using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank4Us.BusinessLayer.Managers.MortgageManagement;
using Bank4Us.BusinessLayer.Managers.MortgageApplicantManagement;
using Bank4Us.DataAccess.Core;
using Microsoft.Extensions.Logging;
using Bank4Us.BusinessLayer.Managers.LoanOfficerManagement;

namespace Bank4Us.BusinessLayer.Core
{
    /// <summary>
    ///   Course Name: MSCS 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Ziwei Huang
    ///   Description: Example implementation of a Business Layer              
    /// </summary>
    /// 
    public class BusinessManagerFactory
    {
        IMortgageManager _mortgageManager;
        IMortgageApplicantManager _applicantManager;
        IPersonManager _personManager;
        ICreditReportManager _creditReportManager;
        ILoanOfficerManager _loanOfficerManager;

        public BusinessManagerFactory(IMortgageManager mortgageManager=null, IMortgageApplicantManager applicantManager=null, 
            IPersonManager personManager=null, ICreditReportManager creditReportManager=null, ILoanOfficerManager loanOfficerManager=null)
        {
            _mortgageManager = mortgageManager;
            _applicantManager = applicantManager;
            _personManager = personManager;
            _creditReportManager = creditReportManager;
            _loanOfficerManager = loanOfficerManager;
        }

        public IMortgageManager GetMortgageManager()
        {
            return _mortgageManager;
        }

        public IMortgageApplicantManager GetMortgageApplicantManager()
        {
            return _applicantManager;
        }

        public IPersonManager GetPersonManager()
        {
            return _personManager;
        }

        public ICreditReportManager GetCreditReportManager()
        {
            return _creditReportManager;
        }

        public ILoanOfficerManager GetLoanOfficerManager()
        {
            return _loanOfficerManager;
        }

    }
}
