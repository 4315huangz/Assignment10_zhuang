using Bank4Us.BusinessLayer.Core;
using Bank4Us.Common.CanonicalSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bank4Us.BusinessLayer.Managers.MortgageManagement
{
    /// <summary>
    ///   Course Name: MSCS 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Ziwei Huang
    ///   Description: Example implementation of a Business Layer              
    /// </summary>
    /// 
    public interface IPersonManager : IActionManager
    {
        Person GetPerson(int Id);

        IEnumerable<Person> GetAllPerson();
    }
}
