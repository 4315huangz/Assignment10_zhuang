using System;
using System.Collections.Generic;
using System.Text;
using Bank4Us.Common.CanonicalSchema;
using NRules.Fluent.Dsl;
using Bank4Us.Common.Core;

namespace Bank4Us.BusinessLayer.Rules
{
    public class CreditMinimum : Rule
    {
        public override void Define()
        {
            MortgageApplicant applicant = null;

            //INFO: Left-hand side of the rule.
            //RULE: An applicant with a credit score below 350 must be declined.  
            When()
                .Match<MortgageApplicant>(() => applicant, a => a.CreditReport.CreditScore < 350);

            //INFO: Right-hand side of the rule.
            //REMARK: Set the mortgage status to declined.
            Then()
            .Do(atx => applicant.Mortgages.ForEach(mortgage => mortgage.UpdateMortgageStatus(Mortgage.MortgageStatus.Declined)))
            .Do(atx => applicant.BusinessRuleNotifications.Add("An applicant with a credit score below 350 must be declined."));
        }
    }
}
