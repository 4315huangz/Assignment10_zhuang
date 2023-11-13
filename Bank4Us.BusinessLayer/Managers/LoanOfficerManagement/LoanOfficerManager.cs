using Bank4Us.BusinessLayer.Core;
using Bank4Us.BusinessLayer.Managers.MortgageApplicantManagement;
using Bank4Us.Common.CanonicalSchema;
using Bank4Us.Common.Core;
using Bank4Us.Common.Facade;
using Bank4Us.DataAccess.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank4Us.BusinessLayer.Managers.LoanOfficerManagement
{
    /// <summary>
    ///   Course Name: MSCS 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Ziwei Huang
    ///   Description: Example implementation of a Business Layer              
    /// </summary>
    /// 
    public class LoanOfficerManager : BusinessManager, ILoanOfficerManager
    {
        private IRepository _repository;
        private ILogger<MortgageApplicantManager> _logger;
        private IUnitOfWork _unitOfWork;
        private NRules.ISession _businessRulesEngine;
        private List<String> _businessRuleNotifications;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }

        public List<String> BusinessRuleNotifications
        {
            get
            {
                return _businessRuleNotifications;
            }
        }

        public LoanOfficerManager(IRepository repository, ILogger<MortgageApplicantManager> logger, IUnitOfWork unitOfWork, ISession businessRulesEngine)
        {
            _repository = repository;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _businessRulesEngine = businessRulesEngine;
        }
        public virtual LoanOfficer GetLoanOfficer(int officerId)
        {
            try
            {
                _logger.LogInformation(LoggingEvents.GET_ITEM, "The Loan Officer Id is " + officerId.ToString());
                return _repository.All<LoanOfficer>().Where( l => l.OfficerId == officerId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        ///   INFO: Create new customer with BRE Example.
        ///          https://github.com/NRules/NRules/wiki/Getting-Started
        /// </summary>
        /// <param name="entity"></param>
        public void Create(BaseEntity entity)
        {
            LoanOfficer officer = (LoanOfficer)entity;
            _logger.LogInformation("Creating record for {0}", this.GetType());

            //INFO: Fact assertion.
            _businessRulesEngine.Insert(officer);
            if (officer.Mortgages != null) _businessRulesEngine.InsertAll(officer.Mortgages);

            //INFO: Execute the business rules.  
            _businessRulesEngine.Fire();
            _businessRuleNotifications = officer.BusinessRuleNotifications;

            if (officer.Mortgages != null) _businessRuleNotifications.AddRange(
                officer.Mortgages.SelectMany(o => o.BusinessRuleNotifications).ToList());

            _logger.LogInformation("Executing the business rules for {0}", this.GetType());

            _repository.Create<LoanOfficer>(officer);
            if (officer.State != (int)BaseEntity.EntityState.Ignore) SaveChanges();
            _logger.LogInformation("Record saved for {0}", this.GetType());

        }
        /// <summary>
        ///   INFO: Update customer with  BRE example.
        ///          https://github.com/NRules/NRules/wiki/Getting-Started
        /// </summary>
        /// <param name="entity"></param>
        public void Update(BaseEntity entity)
        {
            LoanOfficer officer = (LoanOfficer)entity;
            _logger.LogInformation("Creating record for {0}", this.GetType());

            //INFO: Fact assertion.
            _businessRulesEngine.Insert(officer);
            if (officer.Mortgages != null) _businessRulesEngine.InsertAll(officer.Mortgages);

            //INFO: Execute the business rules.  
            _businessRulesEngine.Fire();
            _businessRuleNotifications = officer.BusinessRuleNotifications;

            if (officer.Mortgages != null) _businessRuleNotifications.AddRange(
                officer.Mortgages.SelectMany(o => o.BusinessRuleNotifications).ToList());

            _logger.LogInformation("Executing the business rules for {0}", this.GetType());

            _repository.Update<LoanOfficer>(officer);
            if (officer.State != (int)BaseEntity.EntityState.Ignore) SaveChanges();
            _logger.LogInformation("Record saved for {0}", this.GetType());

        }

        public void Delete(BaseEntity entity)
        {
            LoanOfficer officer = (LoanOfficer)entity;
            _logger.LogInformation("Updating record for {0}", this.GetType());
            _repository.Delete<LoanOfficer>(officer);
            SaveChanges();
            _logger.LogInformation("Record deleted for {0}", this.GetType());
        }
        public IEnumerable<BaseEntity> GetAll()
        {
            return _repository.All<LoanOfficer>().ToList<BaseEntity>();
        }
        /// <summary>
        ///   INFO: Return the entire object hierarchy example.  
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LoanOfficer> GetAllLoanOfficers()
        {
            //INFO: EF Lazy loading, make sure to include sub-objects.  E.g. Accounts.
            return _repository.All<LoanOfficer>()
                .Include(c => c.Mortgages)
                .Include(c => c.Person)
                .ToList();
        }


        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}
