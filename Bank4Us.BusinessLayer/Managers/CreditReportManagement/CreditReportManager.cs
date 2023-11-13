using Bank4Us.BusinessLayer.Core;
using Bank4Us.BusinessLayer.Managers.MortgageManagement;
using Bank4Us.Common.CanonicalSchema;
using Bank4Us.Common.Core;
using Bank4Us.Common.Facade;
using Bank4Us.DataAccess.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using NRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bank4Us.BusinessLayer.Managers.CreditReportManagement
{
    /// <summary>
    ///   Course Name: MSCS 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Ziwei Huang
    ///   Description: Example implementation of a Business Layer              
    /// </summary>
    /// 
    public class CreditReportManager : BusinessManager, ICreditReportManager
    {
        private IRepository _repository;
        private ILogger<CreditReportManager> _logger;
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

        public CreditReportManager(IRepository repository, ILogger<CreditReportManager> logger, IUnitOfWork unitOfWork, ISession businessRulesEngine)
        {
            _repository = repository;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _businessRulesEngine = businessRulesEngine;
        }
        public CreditReport GetCreditReport(int ReportId)
        {
            try
            {
                _logger.LogInformation(LoggingEvents.GET_ITEM, "The account Id is " + ReportId.ToString());
                return _repository.All<CreditReport>().Where(a => a.ReportID == ReportId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Create(BaseEntity entity)
        {
            CreditReport report = (CreditReport)entity;
            _logger.LogInformation("Creating record for {0}", this.GetType());

            //INFO: Fact assertion.
            _businessRulesEngine.Insert(report);
            //INFO: Execute the business rules.  
            _businessRulesEngine.Fire();
            _businessRuleNotifications = report.BusinessRuleNotifications;
            _logger.LogInformation("Executing the business rules for {0}", this.GetType());

            _repository.Create<CreditReport>(report);
            if (report.State != (int)BaseEntity.EntityState.Ignore) SaveChanges();
            _logger.LogInformation("Record saved for {0}", this.GetType());
        }
        public void Update(BaseEntity entity)
        {
            CreditReport report = (CreditReport)entity;
            _logger.LogInformation("Updating record for {0}", this.GetType());

            //INFO: Fact assertion.
            _businessRulesEngine.Insert(report);
            //INFO: Execute the business rules.  
            _businessRulesEngine.Fire();
            _businessRuleNotifications = report.BusinessRuleNotifications;
            _logger.LogInformation("Executing the business rules for {0}", this.GetType());


            _repository.Update<CreditReport>(report);
            if (report.State != (int)BaseEntity.EntityState.Ignore) SaveChanges();
            _logger.LogInformation("Record saved for {0}", this.GetType());
        }

        public void Delete(BaseEntity entity)
        {
            CreditReport report = (CreditReport)entity;
            _logger.LogInformation("Updating record for {0}", this.GetType());
            _repository.Delete<CreditReport>(report);
            SaveChanges();
            _logger.LogInformation("Record delete for {0}", this.GetType());
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            return _repository.All<CreditReport>().ToList<BaseEntity>();
        }

        public IEnumerable<CreditReport> GetAllCreditReports()
        {
            return _repository.All<CreditReport>().ToList();
        }


        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

    }
}
