using Bank4Us.BusinessLayer.Core;
using Bank4Us.Common.CanonicalSchema;
using Bank4Us.Common.Core;
using Bank4Us.Common.Facade;
using Bank4Us.DataAccess.Core;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using NRules;
using NRules.Fluent;
using NRules.RuleModel;
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

    public class MortgageApplicantManager : BusinessManager, IMortgageApplicantManager
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
        public MortgageApplicantManager(IRepository repository, ILogger<MortgageApplicantManager> logger, IUnitOfWork unitOfWork, NRules.ISession businessRulesEngine) : base()
        {
            _repository = repository;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _businessRulesEngine = businessRulesEngine;
        }
        public virtual MortgageApplicant GetMortgageApplicant(int applicantId)
        {
            try
            {
                _logger.LogInformation(LoggingEvents.GET_ITEM, "The applicant Id is " + applicantId.ToString());
                return _repository.All<MortgageApplicant>().Where(a => a.ApplicantID == applicantId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        ///   INFO: Create new applicant with BRE Example.
        ///          https://github.com/NRules/NRules/wiki/Getting-Started
        /// </summary>
        /// <param name="entity"></param>
        public void Create(BaseEntity entity)
        {
            MortgageApplicant applicant = (MortgageApplicant)entity;
            _logger.LogInformation("Creating record for {0}", this.GetType());

            //INFO: Fact assertion.
            _businessRulesEngine.Insert(applicant);
            if (applicant.Mortgages != null) _businessRulesEngine.InsertAll(applicant.Mortgages);

            //INFO: Execute the business rules.  
            _businessRulesEngine.Fire();
            _businessRuleNotifications = applicant.BusinessRuleNotifications;

            if (applicant.Mortgages != null) _businessRuleNotifications.AddRange(
                applicant.Mortgages.SelectMany(a => a.BusinessRuleNotifications).ToList());

            _logger.LogInformation("Executing the business rules for {0}", this.GetType());

            _repository.Create<MortgageApplicant>(applicant);
            if (applicant
                .State != (int)BaseEntity.EntityState.Ignore) SaveChanges();
            _logger.LogInformation("Record saved for {0}", this.GetType());

        }
        /// <summary>
        ///   INFO: Update applicant with  BRE example.
        ///          https://github.com/NRules/NRules/wiki/Getting-Started
        /// </summary>
        /// <param name="entity"></param>
        public void Update(BaseEntity entity)
        {
            MortgageApplicant applicant = (MortgageApplicant)entity;
            _logger.LogInformation("Updating record for {0}", this.GetType());

            //INFO: Fact assertion.
            _businessRulesEngine.Insert(applicant);
            if (applicant.Mortgages != null) _businessRulesEngine.InsertAll(applicant.Mortgages);

            //INFO: Execute the business rules.  
            _businessRulesEngine.Fire();
            _businessRuleNotifications = applicant.BusinessRuleNotifications;

            if (applicant.Mortgages != null) _businessRuleNotifications.AddRange(
                applicant.Mortgages.SelectMany(a => a.BusinessRuleNotifications).ToList());

            _logger.LogInformation("Executing the business rules for {0}", this.GetType());

            _repository.Update<MortgageApplicant>(applicant);
            if (applicant.State != (int)BaseEntity.EntityState.Ignore) SaveChanges();
            _logger.LogInformation("Record saved for {0}", this.GetType());
        }

        public void Delete(BaseEntity entity)
        {
            MortgageApplicant applicant = (MortgageApplicant)entity;
            _logger.LogInformation("Updating record for {0}", this.GetType());
            _repository.Delete<MortgageApplicant>(applicant);
            SaveChanges();
            _logger.LogInformation("Record deleted for {0}", this.GetType());
        }


        public IEnumerable<BaseEntity> GetAll()
        {
            return _repository.All<MortgageApplicant>().ToList<BaseEntity>();
        }
        /// <summary>
        ///   INFO: Return the entire object hierarchy.  
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MortgageApplicant> GetAllMortgageApplicants()
        {
            //INFO: EF Lazy loading, make sure to include sub-objects.  E.g. Mortgages and credit report.
            return _repository
                .All<MortgageApplicant>()
                .Include(c => c.Mortgages)
                .Include(c => c.CreditReport)
                .Include(c=> c.Person)
                .ToList();
        }
        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}
