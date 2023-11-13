using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bank4Us.ServiceApp.Filters;
using Bank4Us.Common.CanonicalSchema;
using Bank4Us.BusinessLayer.Managers.LoanOfficerManagement;
using Bank4Us.Common.Facade;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Bank4Us.ServiceApp.Controllers
{

    /// <summary>
    ///   Course Name: MSCS 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Ziwei Huang
    ///   Description: Example implementation of a Service App with MVC           
    /// </summary>
    /// 
    [LoggingActionFilter]
    [Route("api/[controller]")]
    public class LoanOfficerController : BaseController
    {
         
        LoanOfficerManager _manager;
        ILogger<LoanOfficerController> _logger;

        public LoanOfficerController(ILoanOfficerManager manager, ILogger<LoanOfficerController> logger) : base(manager, logger)
        {
            _manager = (LoanOfficerManager)manager;
            _logger = logger;
        }

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
        [Route("loanofficers")]
        public IActionResult GetAllLoanOfficers()
        {
            try
            {
                var items = _manager.GetAllLoanOfficers();
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
        public IActionResult Post([FromBody] LoanOfficer officer)
        {
            try
            {
                _manager.Create(officer);
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
        public IActionResult Put(LoanOfficer officer)
        {
            try
            {
                _manager.Update(officer);
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
        public IActionResult Delete(LoanOfficer officer)
        {
            try
            {
                _manager.Delete(officer);
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
        [Route("loanofficers/{officerId}")]
        public IActionResult GetLoanOfficerByOfficerId(int officerId)
        {
            try
            {
                var officer = _manager.GetLoanOfficer(officerId);
                if (officer != null)
                {
                    return new OkObjectResult(officer);
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

      