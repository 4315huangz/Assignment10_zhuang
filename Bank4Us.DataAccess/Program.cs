using Bank4Us.DataAccess.Core;
﻿using System;
using System.Collections.Generic;
using Bank4Us.Common.CanonicalSchema;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.AspNetCore.Identity;

namespace Bank4Us.DataAccess
{
    /// <summary>
    ///   Course Name: COSC 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Ziwei Huang
    ///   Description: Example implementation of Entity Framework Core.
    ///                 http://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx  
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //INFO: Create a new database context.  
            DataContext db = new DataContext();

            //INFO: Create the person profile for loan officer
            Person p = new Person()
            {
                SSN = "1234567890",
                FirstName = "Fred",
                LastName = "Jones",
                Gender = "M",
                Birthdate = new DateTime(1995, 3, 11),
                Address = "888 Back Rd, Milwaukee, WI 53233",
                PhoneNumber = "414-555-8888",
                EmailAddress = "Fred.Jones@gmail.com",
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin"
            };
            //INFO: create the loan officer and link to the person profile created above
            LoanOfficer loanOfficer = new LoanOfficer()
            {
                Title = "Mortgage Underwriter",
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin"
            };
            loanOfficer.Person = p;

            //INFO: Create the person profile for new applicant
            Person p1 = new Person()
            {
                SSN = "1111111111",
                FirstName = "Sarah",
                LastName = "White",
                Gender = "F",
                Birthdate = new DateTime(1995, 8, 21),
                Address = "444 Wisconsin Rd, Milwaukee, WI 53233",
                PhoneNumber = "414-666-7777",
                EmailAddress = "Sarah.White@gmail.com",
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin"
            };
            //INFO: Create a credit report
            CreditReport creditReport = new CreditReport()
            {
                ReportDate = new DateTime(2023, 11, 06),
                CreditScore = 750,
                OutstandingDebt = 500000.00,
                CreatedBy = "admin",
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin",
                CreatedOn = DateTime.Now
            };
            //INFO: Create the applicant info and link to the person profile created in p2
            // also link to the credit report created above
            MortgageApplicant mortgageApplicant = new MortgageApplicant()
            {
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin"
            };

            mortgageApplicant.Person = p1;
            mortgageApplicant.CreditReport = creditReport;

            //INFO: Create the new Mortgage, link to loan officer, applicant and 
            Mortgage mortgage = new Mortgage()
            {

                PropertyAddress = "555 cherry rd, Milwaukee, WI 53233",
                LoanAmount = 300000,
                LoanTerm = 30,
                InterestRate = 7.12,
                MonthlyPayment = 3200,
                CreatedBy = "admin",
                UpdatedBy = "admin",
                UpdatedOn = DateTime.Now,
                CreatedOn = DateTime.Now
            };
            ////INFO: Link the mortgage to the applicant.
            mortgageApplicant.Mortgages = new List<Mortgage>();
            mortgageApplicant.Mortgages.Add(mortgage);

            ////INFO: Link the mortgage to the loan officer.
            loanOfficer.Mortgages = new List<Mortgage>();
            loanOfficer.Mortgages.Add(mortgage);

            //INFO: Add the applicants to the database.
            db.MortgageApplicants.Add(mortgageApplicant);
            //INFO: Add the loan officer to the database.
            db.LoanOfficers.Add(loanOfficer);
            db.Save();

        }
    }
}