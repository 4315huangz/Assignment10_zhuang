// See https://aka.ms/new-console-template for more information
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
    public class Program
    {
        //INFO: Database factory.
        static DbFactory _dfactory = new DbFactory(new DataContext());

        //INFO: Create a new database repo.  
        static Repository _rep = new Repository(_dfactory);

        //INFO: Transaction management
        static UnitOfWork _uow = new UnitOfWork(_dfactory);

        static void Main(string[] args)
        {

            CreateMortgage();

            //UpdateMortgage();
            //CreateMorerecords();

            Console.WriteLine("Process complete...");
            Console.ReadKey();
        }

        /// <summary>
        ///   INFO: Demo creating database records.  
        /// </summary>
       
        //INFO: Create a new Mortgage.
        private static void CreateMortgage()
        {
            //INFO: Create the person profile for loan officer
            Person p1 = new Person()
            {
                SSN = 1234567890,
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
            loanOfficer.Person = p1;

            //INFO: Create the person profile for new applicant
            Person p2 = new Person()
            {
                SSN = 1111111111,
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
            
            mortgageApplicant.Person = p2;
            mortgageApplicant.CreditReport = creditReport;

            //INFO: Create the new Mortgage, link to loan officer, applicant and 
            Mortgage mortgage = new Mortgage()
            {
                
                PropertyAddress = "555 cherry rd, Milwaukee, WI 53233",
                LoanAmount = 300000,
                LoanTerm = 30,
                InterestRate=7.12,
                MonthlyPayment=3200,
                ApproveStatus=true,
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

            //INFO: Add the mortgage,loan officer, two persons, applicant and credit report to the repo.
            _rep.Create<Mortgage>(mortgage);
            _rep.Create<Person>(p1);
            _rep.Create<Person>(p2);
            _rep.Create<LoanOfficer>(loanOfficer);
            _rep.Create<CreditReport>(creditReport);
            _rep.Create<MortgageApplicant>(mortgageApplicant);

            //INFO: Save the changes to the database.  
            _uow.SaveChanges();
        }

        /// <summary>
        ///   INFO: Demo Updating records with schema changes.  
        /// </summary>
        private static void UpdateMortgage()
        {
            //INFO: Retrieve the record from the database.   
            Mortgage m =
                _rep.Find<Mortgage>(m => m.MortgageId.Equals(3));

            //INFO: Update new property.
            if (m != null)
            {
               m.LoanAmount = 400000;
            }

            //INFO: Update the record in the database.
            _uow.SaveChanges();

        }
        //INFO: Create a new Mortgage.
        private static void CreateMorerecords()
        {
            //INFO: Create the person profile for loan officer
            Person p1 = new Person()
            {
                SSN = 222222222,
                FirstName = "Rosella",
                LastName = "Burks",
                Gender = "M",
                Birthdate = new DateTime(1990, 1, 11),
                Address = "888 Back Rd, Milwaukee, WI 53233",
                PhoneNumber = "222-222-2222",
                EmailAddress = "BurksR@univ.edu",
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin"
            };
            Person p2 = new Person()
            {
                SSN = 333333333,
                FirstName = "Damien",
                LastName = "Avila",
                Gender = "M",
                Birthdate = new DateTime(1989, 9, 25),
                Address = "888 Back Rd, Milwaukee, WI 53233",
                PhoneNumber = "333-333-3333",
                EmailAddress = "AvilaD@univ.edu",
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin"
            };
            Person p3 = new Person()
            {
                SSN = 444444444,
                FirstName = "Edgar",
                LastName = "Moises",
                Gender = "M",
                Birthdate = new DateTime(1992, 6, 10),
                Address = "888 Back Rd, Milwaukee, WI 53233",
                PhoneNumber = "444-555-8888",
                EmailAddress = "MoisesE@univ.edu",
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin"
            };
            Person p4 = new Person()
            {
                SSN = 555555555,
                FirstName = "Heath",
                LastName = "Brian",
                Gender = "M",
                Birthdate = new DateTime(1995, 3, 11),
                Address = "888 Back Rd, Milwaukee, WI 53233",
                PhoneNumber = "963-555-2800",
                EmailAddress = "BrianH@univ.edu",
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin"
            };
            //INFO: create the loan officer and link to the person profile created above
            LoanOfficer loanOfficer1 = new LoanOfficer()
            {
                Title = "Mortgage Underwriter",
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin"
            };
            LoanOfficer loanOfficer2 = new LoanOfficer()
            {
                Title = "Mortgage Underwriter",
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin"
            };
            LoanOfficer loanOfficer3 = new LoanOfficer()
            {
                Title = "Mortgage Manager",
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin"
            };
            LoanOfficer loanOfficer4 = new LoanOfficer()
            {
                Title = "Mortgage Issuer",
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin"
            };
            loanOfficer1.Person = p1;
            loanOfficer2.Person = p2;
            loanOfficer3.Person = p3;
            loanOfficer4.Person = p4;

            //INFO: Create the person profile for new applicant
            Person p5 = new Person()
            {
                SSN = 666666666,
                FirstName = "Elvin",
                LastName = "Claude",
                Gender = "M",
                Birthdate = new DateTime(1991, 6, 21),
                Address = "444 Wisconsin Rd, Milwaukee, WI 53233",
                PhoneNumber = "666-666-7777",
                EmailAddress = "Elvin.Claude@gmail.com",
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin"
            };
            Person p6 = new Person()
            {
                SSN = 777777777,
                FirstName = "Edmund",
                LastName = "Mosley",
                Gender = "M",
                Birthdate = new DateTime(1996, 1, 1),
                Address = "444 Wisconsin Rd, Milwaukee, WI 53233",
                PhoneNumber = "777-777-7777",
                EmailAddress = "Edmund.Mosley@gmail.com",
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin"
            };
            Person p7 = new Person()
            {
                SSN = 888888888,
                FirstName = "Antoine",
                LastName = "Derek",
                Gender = "M",
                Birthdate = new DateTime(1989, 5, 19),
                Address = "444 Wisconsin Rd, Milwaukee, WI 53233",
                PhoneNumber = "888-888-8888",
                EmailAddress = "Antoine.Derek@gmail.com",
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin"
            };
            Person p8 = new Person()
            {
                SSN = 999999999,
                FirstName = "Callie",
                LastName = "Hawkins",
                Gender = "F",
                Birthdate = new DateTime(1994, 4, 8),
                Address = "444 Wisconsin Rd, Milwaukee, WI 53233",
                PhoneNumber = "999-999-9999",
                EmailAddress = "Callie.Hawkins@gmail.com",
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin"
            };
            //INFO: Create a credit report
            CreditReport creditReport1 = new CreditReport()
            {
                ReportDate = new DateTime(2023, 11, 06),
                CreditScore = 680,
                OutstandingDebt = 500000.00,
                CreatedBy = "admin",
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin",
                CreatedOn = DateTime.Now
            };
            CreditReport creditReport2 = new CreditReport()
            {
                ReportDate = new DateTime(2023, 10, 06),
                CreditScore = 800,
                OutstandingDebt = 700000.00,
                CreatedBy = "admin",
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin",
                CreatedOn = DateTime.Now
            };
            CreditReport creditReport3 = new CreditReport()
            {
                ReportDate = new DateTime(2023, 11, 01),
                CreditScore = 720,
                OutstandingDebt = 200000.00,
                CreatedBy = "admin",
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin",
                CreatedOn = DateTime.Now
            };
            CreditReport creditReport4 = new CreditReport()
            {
                ReportDate = new DateTime(2023, 10, 06),
                CreditScore = 700,
                OutstandingDebt = 450000.00,
                CreatedBy = "admin",
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin",
                CreatedOn = DateTime.Now
            };
            //INFO: Create the applicant info and link to the person profile created in p2
            // also link to the credit report created above
            MortgageApplicant mortgageApplicant1 = new MortgageApplicant()
            {
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin"
            };
            MortgageApplicant mortgageApplicant2 = new MortgageApplicant()
            {
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin"
            };
            MortgageApplicant mortgageApplicant3 = new MortgageApplicant()
            {
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin"
            };
            MortgageApplicant mortgageApplicant4 = new MortgageApplicant()
            {
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = "admin"
            };

            mortgageApplicant1.Person = p5;
            mortgageApplicant1.CreditReport = creditReport1;
            mortgageApplicant2.Person = p6;
            mortgageApplicant2.CreditReport = creditReport2;
            mortgageApplicant3.Person = p7;
            mortgageApplicant3.CreditReport = creditReport3;
            mortgageApplicant4.Person = p8;
            mortgageApplicant4.CreditReport = creditReport4;

            //INFO: Create the new Mortgage, link to loan officer, applicant and 
            Mortgage mortgage1 = new Mortgage()
            {

                PropertyAddress = "111 first rd, Milwaukee, WI 53233",
                LoanAmount = 300000,
                LoanTerm = 30,
                InterestRate = 7.12,
                MonthlyPayment = 3200,
                ApproveStatus = true,
                CreatedBy = "admin",
                UpdatedBy = "admin",
                UpdatedOn = DateTime.Now,
                CreatedOn = DateTime.Now
            };
            Mortgage mortgage2 = new Mortgage()
            {

                PropertyAddress = "222 second rd, Milwaukee, WI 53233",
                LoanAmount = 356000,
                LoanTerm = 15,
                InterestRate = 6.12,
                MonthlyPayment = 2500,
                ApproveStatus = true,
                CreatedBy = "admin",
                UpdatedBy = "admin",
                UpdatedOn = DateTime.Now,
                CreatedOn = DateTime.Now
            };
            Mortgage mortgage3 = new Mortgage()
            {

                PropertyAddress = "333 third rd, Milwaukee, WI 53233",
                LoanAmount = 650000,
                LoanTerm = 30,
                InterestRate = 7.00,
                MonthlyPayment = 3500,
                ApproveStatus = true,
                CreatedBy = "admin",
                UpdatedBy = "admin",
                UpdatedOn = DateTime.Now,
                CreatedOn = DateTime.Now
            };
            Mortgage mortgage4 = new Mortgage()
            {

                PropertyAddress = "444 fourth rd, Milwaukee, WI 53233",
                LoanAmount = 855000,
                LoanTerm = 30,
                InterestRate = 6.89,
                MonthlyPayment = 4500,
                ApproveStatus = true,
                CreatedBy = "admin",
                UpdatedBy = "admin",
                UpdatedOn = DateTime.Now,
                CreatedOn = DateTime.Now
            };
            ////INFO: Link the mortgage to the applicant.
            mortgageApplicant1.Mortgages = new List<Mortgage>();
            mortgageApplicant1.Mortgages.Add(mortgage1);
            mortgageApplicant2.Mortgages = new List<Mortgage>();
            mortgageApplicant2.Mortgages.Add(mortgage2);
            mortgageApplicant3.Mortgages = new List<Mortgage>();
            mortgageApplicant3.Mortgages.Add(mortgage3);
            mortgageApplicant4.Mortgages = new List<Mortgage>();
            mortgageApplicant4.Mortgages.Add(mortgage4);

            ////INFO: Link the mortgage to the loan officer.
            loanOfficer1.Mortgages = new List<Mortgage>();
            loanOfficer1.Mortgages.Add(mortgage1);
            loanOfficer2.Mortgages = new List<Mortgage>();
            loanOfficer2.Mortgages.Add(mortgage2);
            loanOfficer3.Mortgages = new List<Mortgage>();
            loanOfficer3.Mortgages.Add(mortgage3);
            loanOfficer4.Mortgages = new List<Mortgage>();
            loanOfficer4.Mortgages.Add(mortgage4);

            //INFO: Add the mortgage,loan officer, two persons, applicant and credit report to the repo.
            _rep.Create<Mortgage>(mortgage1);
            _rep.Create<Mortgage>(mortgage2);
            _rep.Create<Mortgage>(mortgage3);
            _rep.Create<Mortgage>(mortgage4);
            _rep.Create<Person>(p1);
            _rep.Create<Person>(p2);
            _rep.Create<Person>(p3);
            _rep.Create<Person>(p4);
            _rep.Create<Person>(p5);
            _rep.Create<Person>(p6);
            _rep.Create<Person>(p7);
            _rep.Create<Person>(p8);

            _rep.Create<LoanOfficer>(loanOfficer1);
            _rep.Create<LoanOfficer>(loanOfficer2);
            _rep.Create<LoanOfficer>(loanOfficer3);
            _rep.Create<LoanOfficer>(loanOfficer4);
            _rep.Create<CreditReport>(creditReport1);
            _rep.Create<CreditReport>(creditReport2);
            _rep.Create<CreditReport>(creditReport3);
            _rep.Create<CreditReport>(creditReport4);
            _rep.Create<MortgageApplicant>(mortgageApplicant1);
            _rep.Create<MortgageApplicant>(mortgageApplicant2);
            _rep.Create<MortgageApplicant>(mortgageApplicant3);
            _rep.Create<MortgageApplicant>(mortgageApplicant4);

            //INFO: Save the changes to the database.  
            _uow.SaveChanges();
        }
    }
}