using Bank4Us.BusinessLayer.Core;
using Bank4Us.BusinessLayer.Managers.MortgageManagement;
using Bank4Us.Common.CanonicalSchema;
using Bank4Us.Common.Core;
using Bank4Us.Common.Facade;
using Bank4Us.DataAccess.Core;
using Microsoft.Extensions.Logging;
using NRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank4Us.BusinessLayer.Managers.PersonManagement
{
    /// <summary>
    ///   Course Name: MSCS 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Ziwei Huang
    ///   Description: Example implementation of a Business Layer              
    /// </summary>
    /// 
    public class PersonManager : BusinessManager, IPersonManager
    {
        private IRepository _repository;
        private NRules.ISession _businessRulesEngine;
        private ILogger<PersonManager> _logger;
        private IUnitOfWork _unitOfWork;
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

        public PersonManager(IRepository repository, ISession businessRulesEngine, ILogger<PersonManager> logger, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _businessRulesEngine = businessRulesEngine;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public virtual Person GetPerson(int id) 
        {
            try
            {
                _logger.LogInformation(LoggingEvents.GET_ITEM, "The customer Id is " + id.ToString());
                return _repository.All<Person>().Where(p => p.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///   INFO: Create new person with BRE Example.
        ///          https://github.com/NRules/NRules/wiki/Getting-Started
        /// </summary>
        /// <param name="entity"></param>
        public void Create(BaseEntity entity)
        {
            Person person = (Person)entity;
            _logger.LogInformation("Creating record for {0}", this.GetType());

            //INFO: Fact assertion.
            _businessRulesEngine.Insert(person);
            //INFO: Execute the business rules.  
            _businessRulesEngine.Fire();
            _businessRuleNotifications = person.BusinessRuleNotifications;
            _logger.LogInformation("Executing the business rules for {0}", this.GetType());

            _repository.Create<Person>(person);
            if (person.State != (int)BaseEntity.EntityState.Ignore) SaveChanges();
            _logger.LogInformation("Record saved for {0}", this.GetType());
        }
        public void Update(BaseEntity entity)
        {
            Person person = (Person)entity;
            _logger.LogInformation("Updating record for {0}", this.GetType());

            //INFO: Fact assertion.
            _businessRulesEngine.Insert(person);
            //INFO: Execute the business rules.  
            _businessRulesEngine.Fire();
            _businessRuleNotifications = person.BusinessRuleNotifications;
            _logger.LogInformation("Executing the business rules for {0}", this.GetType());

            _repository.Update<Person>(person);
            if (person.State != (int)BaseEntity.EntityState.Ignore) SaveChanges();
            _logger.LogInformation("Record saved for {0}", this.GetType());

        }
        public void Delete(BaseEntity entity)
        {
            Person person = (Person)entity;
            _logger.LogInformation("Updating record for {0}", this.GetType());
            _repository.Delete<Person>(person);
            SaveChanges();
            _logger.LogInformation("Record deleted for {0}", this.GetType());
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            return _repository.All<Person>().ToList<BaseEntity>();
        }

        /// <summary>
        ///   INFO: Return the entire object hierarchy example.  
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Person> GetAllPerson()
        {
            return _repository.All<Person>().ToList();
        }


        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

    }
}
