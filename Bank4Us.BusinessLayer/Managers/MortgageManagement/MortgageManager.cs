using Bank4Us.BusinessLayer.Core;
using Bank4Us.Common.CanonicalSchema;
using Bank4Us.Common.Core;
using Bank4Us.Common.Facade;
using Bank4Us.DataAccess.Core;
using Microsoft.Extensions.Logging;
using Bank4Us.BusinessLayer.Managers.MortgageManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank4Us.BusinessLayer.Managers.MortgageApplicantManagement;

namespace Bank4Us.BusinessLayer.Managers.MortgageManagement
{
    /// <summary>
    ///   Course Name: MSCS 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Ziwei Huang
    ///   Description: Example implementation of a Business Layer              
    /// </summary>
    /// 
    public class MortgageManager : BusinessManager, IMortgageManager
    {
        private IRepository _repository;
        private ILogger<MortgageManager> _logger;
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

        public MortgageManager(IRepository repository, ILogger<MortgageManager> logger, IUnitOfWork unitOfWork, IMortgageApplicantManager serviceRequestManager, NRules.ISession businessRulesEngine) : base()
        {
            _repository = repository;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _businessRulesEngine = businessRulesEngine;
        }

        public virtual Mortgage GetMortgage(int MortgageId)
        {
            try
            {
                _logger.LogInformation(LoggingEvents.GET_ITEM, "The mortgage Id is " + MortgageId.ToString());
                return _repository.All<Mortgage>().Where(m => m.MortgageId == MortgageId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Create(BaseEntity entity)
        {
            Mortgage mortgage = (Mortgage)entity;
            _logger.LogInformation("Creating record for {0}", this.GetType());

            //INFO: Fact assertion.
            _businessRulesEngine.Insert(mortgage);
            //INFO: Execute the business rules.  
            _businessRulesEngine.Fire();
            _businessRuleNotifications = mortgage.BusinessRuleNotifications;
            _logger.LogInformation("Executing the business rules for {0}", this.GetType());

            _repository.Create<Mortgage>(mortgage);
            SaveChanges();
            _logger.LogInformation("Record saved for {0}", this.GetType());
        }

        public void Update(BaseEntity entity)
        {
            Mortgage mortgage = (Mortgage)entity;
            _logger.LogInformation("Updating record for {0}", this.GetType());

            //INFO: Fact assertion.
            _businessRulesEngine.Insert(mortgage);
            //INFO: Execute the business rules.  
            _businessRulesEngine.Fire();
            _businessRuleNotifications = mortgage.BusinessRuleNotifications;
            _logger.LogInformation("Executing the business rules for {0}", this.GetType());

            _repository.Update<Mortgage>(mortgage);
            SaveChanges();
            _logger.LogInformation("Record saved for {0}", this.GetType());
        }

        public void Delete(BaseEntity entity)
        {
            Mortgage mortgage = (Mortgage)entity;
            _logger.LogInformation("Updating record for {0}", this.GetType());
            _repository.Delete<Mortgage>(mortgage);
            SaveChanges();
            _logger.LogInformation("Record deleted for {0}", this.GetType());
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            return _repository.All<Mortgage>().ToList<BaseEntity>();
        }

        public IEnumerable<Mortgage> GetAllMortgages()
        {
            return _repository.All<Mortgage>().ToList();
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }


    }

}
