import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators} from "@angular/forms";
import { MortgageApplicantService } from "../serviceapp/proxies/mortgageapplicant.service";
import { MortgageApplicant } from "../serviceapp/proxies/mortgageapplicant.model";
import { Mortgage } from "../serviceapp/proxies/mortgage.model";
import { Person } from "../serviceapp/proxies/person.model";
import { CreditReport } from "../serviceapp/proxies/creditreport.model";
import { Router } from "@angular/router";

@Component({
  selector: 'app-add-mortgageapplicant',
  templateUrl: './addmortgageapplicant.component.html',
  providers: [MortgageApplicantService]
})
export class AddMortgageApplicantComponent implements OnInit {

  constructor(private formBuilder: FormBuilder,
    private router: Router,
    private mortgageApplicantService: MortgageApplicantService) { }
  
  addForm: FormGroup;

  ngOnInit() {

    //INFO: Init the form.   
    this.addForm = this.formBuilder.group({
      ssn: [],
      firstName: [],
      lastName: [],
      address: [],
      gender: [],
      birthdate: [],
      email: [],
      phonenumber: [],
      reportdate: [],
      creditscore: [],
      outstandingbalance: [],
      propertysddress: [],
      interestrate: [],
      loanamount: [],
      loanterm: [],
      monthlypayment: []
    });

  }

  onSubmit() {


    //INFO: Only submit the new customer if the form is valid.  
    if (this.addForm.valid) {

    //INFO: Map the form data into the customer object.
      let addmortgageapplicant = new MortgageApplicant();

      let addPerson = new Person();
      addPerson.ssn = this.addForm.value.ssn;
      addPerson.firstName = this.addForm.value.firstName;
      addPerson.lastName = this.addForm.value.lastName;
      addPerson.address = this.addForm.value.address ||'';
      addPerson.gender = this.addForm.value.gender || '';
      addPerson.birthdate = this.addForm.value.birthdate;
      addPerson.emailAddress = this.addForm.value.email || '';
      addPerson.phoneNumber = this.addForm.value.phonenumber || '';

      let addCreditReport = new CreditReport();
      addCreditReport.reportDate = this.addForm.value.reportDate || new Date();
      addCreditReport.creditScore = this.addForm.value.creditScore || 0;
      addCreditReport.outstandingDebt = this.addForm.value.outstandingbalance || 0;

      let addMortgage = new Mortgage();
      addMortgage.propertyAddress = this.addForm.value.propertyAddress;
      addMortgage.interestRate = this.addForm.value.interestRate;
      addMortgage.loanAmount = this.addForm.value.loanAmount;
      addMortgage.loanTerm = this.addForm.value.loanTerm;
      addMortgage.monthlyPayment = this.addForm.value.monthlyPayment;

      addmortgageapplicant.person = addPerson;
      addmortgageapplicant.creditReport= addCreditReport;
      addmortgageapplicant.mortgages = new Array<Mortgage>();
      addmortgageapplicant.mortgages.push(addMortgage);
      addmortgageapplicant.createdBy = "admin";

     //INFO: Clear out old messages.
    document.getElementById("rulemessages").innerHTML = "";

      this.mortgageApplicantService.createMortgageApplicant(addmortgageapplicant)
      .subscribe(result => {
        if (result != null && Object.values(result).length > 0) {
          var x;
          var msgs = Object.values(result);
          //INFO: Business rule violations.  
          for (x in msgs) {
            document.getElementById("rulemessages").innerHTML += msgs[x] + "<br>";
          }
        }
        else {
          //INFO: update worked, returned to the list.  
          this.router.navigate(['listmortgageapplicant']);
        }
      }, ex => {
        //INFO: Standard error handling.  
        alert("Failed to create the mortgage applicant record: " + ex.status + " " + ex.error);
      }
      );
    }
  }
}
