using Bank4Us.BusinessLayer.Core;
using Bank4Us.BusinessLayer.Managers.PersonManagement;
using Bank4Us.Common.CanonicalSchema;
using Bank4Us.Common.Facade;
using Bank4Us.ServiceApp.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Bank4Us.ServiceApp.Controllers
{
    /// <summary>
    ///   Course Name: MSCS 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Ziwei Huang
    ///   Description: Example implementation of a Service App with MVC           
    /// </summary>
    /// 

    // [Authorize]
    [LoggingActionFilter]
    [Route("api/[controller]")]
    public class PersonController : BaseController
    {
        private PersonManager _manager;
        private ILogger _logger;

        public PersonController(IActionManager manager, ILogger<PersonController> logger) : base(manager, logger)
        {
            _manager = (PersonManager)manager;
            _logger = logger;
        }
        // GET: api/values

        [TransactionActionFilter()]
        [HttpGet]
        [Route("baseentities")]
        public IActionResult GetAllBaseEntities()
        {
            try
            {
                var items = _manager.GetAll();
                return new OkObjectResult(items);

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }
        [TransactionActionFilter()]
        [HttpGet]
        [Route("person")]
        public IActionResult GatAllPerson()
        {
            try
            {
                var items = _manager.GetAllPerson();
                return new OkObjectResult(items);

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }

        [TransactionActionFilter()]
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            try
            {
                _manager.Create(person);
                return new OkObjectResult(_manager.BusinessRuleNotifications);

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }

        [TransactionActionFilter()]
        [HttpPut]
        public IActionResult Put(Person person)
        {
            try
            {
                _manager.Update(person);
                return new OkObjectResult(_manager.BusinessRuleNotifications);
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }
        [TransactionActionFilter()]
        [HttpDelete]
        public IActionResult Delete(Person person)
        {
            try
            {
                _manager.Delete(person);
                return new OkResult();

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }

        [TransactionActionFilter()]
        [HttpGet]
        [Route("person/{id}")]
        public IActionResult GetPersonById(int id)
        {
            try 
            {
                var person = _manager.GetPerson(id);
                if(person != null)
                {
                    return new OkObjectResult(person);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }
    }
}
