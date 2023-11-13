using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using System;


namespace Bank4Us.Common.Core
{
    /// <summary>
    ///   Course Name: COSC 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Ziwei Huang
    ///   Description: Example implementation of Entity Framework Core.
    ///                 http://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx  
    /// </summary>
    public abstract class BaseEntity
    {
        public BaseEntity() {
            this.CreatedOn = DateTime.Now;
            this.UpdatedOn = DateTime.Now;
            this.State = (int)EntityState.New;
            this.BusinessRuleNotifications = new List<string>();

        }
        [JsonIgnore]
        public string CreatedBy { get; set; }
        [JsonIgnore]
        public DateTime CreatedOn { get; set; }
        [JsonIgnore]
        public string UpdatedBy { get; set; }
        [JsonIgnore]
        public DateTime UpdatedOn { get; set; }
        [NotMapped]
        [JsonIgnore]
        public int State { get; set; }
        public void UpdateState(EntityState es)
        {
            State = (int)es;
        }
        [NotMapped]
        [JsonIgnore]
        public List<String> BusinessRuleNotifications { get; set; }

        public enum EntityState
        {
            New = 1,
            Update = 2,
            Delete = 3,
            Ignore = 4
        }
    }
}
