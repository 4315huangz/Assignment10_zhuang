using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank4Us.Common.Facade
{
    /// <summary>
    ///   Course Name: COSC 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Ziwei Huang
    ///   Description: Example implementation of Entity Framework Core.
    ///                 http://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx  
    /// </summary>
    internal class LoggingEvents
    {
        public const int GET_ITEM = 1001;
        public const int GET_ITEMS = 1002;
        public const int CREATE_ITEM = 1003;
        public const int UPDATE_ITEM = 1004;
        public const int DELETE_ITEM = 1005;
        public const int DATABASE_ERROR = 2000;
        public const int SERVICE_ERROR = 2001;
        public const int ERROR = 2002;
        public const int ACCESS_METHOD = 3000;
    }
}
