
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank4Us.Common.CanonicalSchema;
using NRules.Fluent.Dsl;

namespace Bank4Us.BusinessLayer.Rules
{
    public class AdultApplyRule : Rule
    {
        public override void Define()
        {
            MortgageApplicant applicant = null;

            //INFO: Left-hand side of the rule.
            //RULE: An applicant must be an adult to apply for a mortgage.  
            When()
                .Match<MortgageApplicant>(() => applicant, a => (a.Person.Birthdate.Year - DateTime.Now.Year) < 18 );

            //INFO: Right-hand side of the rule.!
            //REMARK: Remove mortgage action, then notify user.  
            Then()
                .Do(ctx => applicant.Mortgages.Clear())
                //.Do(ctx => ctx.Update(applicant)) //<--INFO: Must call the rule context update to forward chain.
                .Do(ctx => applicant.BusinessRuleNotifications.Add("A mortgage applicant must be at least 18 to apply for a mortgage."));
        }
    }
}

