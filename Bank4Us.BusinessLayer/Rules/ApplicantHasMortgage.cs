using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank4Us.Common.CanonicalSchema;
using NRules.Fluent.Dsl;
using Bank4Us.Common.Core;

namespace Bank4Us.BusinessLayer.Rules
{
    public class ApplicantHasMortgage : Rule
    {
        public override void Define()
        {
            MortgageApplicant applicant= null;

            //INFO: Left-hand side of the rule.
            //RULE: An applicant must have an mortgage application. 
            When()
                .Match<MortgageApplicant>(() => applicant, a => a.Mortgages == null || a.Mortgages.Count == 0);

            //INFO: Right-hand side of the rule.
            //REMARK: Set the applicant record to ignore.    
            Then()
                .Do(ctx => applicant.UpdateState(BaseEntity.EntityState.Ignore))
                .Do(ctx => applicant.BusinessRuleNotifications.Add("An applicant must have an mortgage application."));
        }
    }
}
