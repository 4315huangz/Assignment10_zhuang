using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bank4Us.Common.CanonicalSchema;
using Bank4Us.BusinessLayer.Managers.MortgageManagement;
using System.Net.Http;
using System.Net;
using Bank4Us.ServiceApp.Filters;
using Bank4Us.BusinessLayer.Core;
using Microsoft.Extensions.Logging;
using Bank4Us.Common.Facade;
using Microsoft.AspNetCore.Authorization;

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

    // [Authorize]
    [LoggingActionFilter]
    [Route("api/[controller]")]
    public class MortgageController : BaseController
    {
         
        private MortgageManager _manager;
        private ILogger _logger;

        public MortgageController(IMortgageManager manager, ILogger<MortgageController> logger) : base(manager, logger)
        {
            _manager = (MortgageManager)manager;
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
        [Route("mortgages")]
        public IActionResult GetAllMortgages()
        {
            try
            {
                var items = _manager.GetAllMortgages();
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
        public IActionResult Post(Mortgage mortgage)
        {
            try
            {
                _manager.Create(mortgage);
                return new OkObjectResult(_manager.BusinessRuleNotifications);

            }catch(Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }
        [TransactionActionFilter()]
        [HttpPut]
        public IActionResult Put(Mortgage mortgage)
        {
            try
            {
                _manager.Update(mortgage);
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
        public IActionResult Delete(Mortgage mortgage)
        {
            try
            {
                _manager.Delete(mortgage);
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
        [Route("mortgages/{mortgageId}")]
        public IActionResult GetMortgageByMortgageId(int mortgageId)
        {
           try 
            {
                var account = _manager.GetMortgage(mortgageId);
                if (account != null)
                {
                    return new OkObjectResult(account);
                }
                else
                {
                    return NotFound();
                }
            }catch(Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }
    }
        
}
