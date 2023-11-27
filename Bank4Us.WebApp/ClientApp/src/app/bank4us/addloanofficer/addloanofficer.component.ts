import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators} from "@angular/forms";
import { LoanOfficerService } from "../serviceapp/proxies/loanofficer.service";
import { LoanOfficer } from "../serviceapp/proxies/loanofficer.model";
import { Mortgage } from "../serviceapp/proxies/mortgage.model";
import { Person } from "../serviceapp/proxies/person.model";
import { Router } from "@angular/router";

@Component({
  selector: 'app-add-loanofficer',
  templateUrl: './addloanofficer.component.html',
  providers: [LoanOfficerService]
})
export class AddLoanOfficerComponent implements OnInit {

  constructor(private formBuilder: FormBuilder,
    private router: Router,
    private loanOfficerService: LoanOfficerService) { }
  
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
      let addloanofficer = new LoanOfficer();

      let addPerson = new Person();
      addPerson.ssn = this.addForm.value.ssn;
      addPerson.firstName = this.addForm.value.firstName;
      addPerson.lastName = this.addForm.value.lastName;
      addPerson.address = this.addForm.value.address ||'';
      addPerson.gender = this.addForm.value.gender || '';
      addPerson.birthdate = this.addForm.value.birthdate;
      addPerson.emailAddress = this.addForm.value.email || '';
      addPerson.phoneNumber = this.addForm.value.phonenumber || '';


      let addMortgage = new Mortgage();
      addMortgage.propertyAddress = this.addForm.value.propertyAddress;
      addMortgage.interestRate = this.addForm.value.interestRate;
      addMortgage.loanAmount = this.addForm.value.loanAmount;
      addMortgage.loanTerm = this.addForm.value.loanTerm;
      addMortgage.monthlyPayment = this.addForm.value.monthlyPayment;

      addloanofficer.person = addPerson;
      addloanofficer.mortgages = new Array<Mortgage>();
      addloanofficer.mortgages.push(addMortgage);
      addloanofficer.createdBy = "admin";

     //INFO: Clear out old messages.
    document.getElementById("rulemessages").innerHTML = "";

      this.loanOfficerService.createLoanOfficer(addloanofficer)
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
          this.router.navigate(['listloanofficer']);
        }
      }, ex => {
        //INFO: Standard error handling.  
        alert("Failed to create the loan officer record: " + ex.status + " " + ex.error);
      }
      );
    }
  }
}
