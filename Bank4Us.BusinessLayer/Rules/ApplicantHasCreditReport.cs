using Bank4Us.Common.CanonicalSchema;
using Bank4Us.Common.Core;
using NRules.Fluent.Dsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank4Us.BusinessLayer.Rules
{
    public class ApplicantHasCreditReport : Rule
    {
        public override void Define()
        {
            MortgageApplicant applicant = null;
            //INFO: Left-hand side of the rule.
            //RULE: A mortgage applicant must have a credit report
            When()
                    .Match<MortgageApplicant>(() => applicant, a => a.CreditReport == null);

            //INFO: Right-hand side of the rule.
            //REMARK: Set the applicant record to ignore.    
            Then()
                .Do(ctx => applicant.UpdateState(BaseEntity.EntityState.Ignore))
                .Do(ctx => applicant.BusinessRuleNotifications.Add("A mortgage applicant must have a credit report."));
        }
     } 
    
}
