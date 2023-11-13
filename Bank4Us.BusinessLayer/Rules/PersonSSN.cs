using System;
using System.Collections.Generic;
using System.Text;
using Bank4Us.Common.CanonicalSchema;
using NRules.Fluent.Dsl;
using Bank4Us.Common.Core;
using System.Runtime.Intrinsics.X86;

namespace Bank4Us.BusinessLayer.Rules
{
    public class PersonSSN : Rule
    {
        public override void Define()
        {
            Person person= null;

            //INFO: Left-hand side of the rule.
            //RULE: A person must have an SSN.  
            When()
                .Match<Person>(() => person, p => String.IsNullOrEmpty(p.SSN));

            //INFO: Right-hand side of the rule.
            //REMARK: Set the person record to ignore.    
            Then()
                .Do(ctx => person.UpdateState(BaseEntity.EntityState.Ignore))
                .Do(ctx => person.BusinessRuleNotifications.Add("A person must have an SSN."));
        }
    }
}
