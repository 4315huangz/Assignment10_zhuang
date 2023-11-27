import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators} from "@angular/forms";
import { LoanOfficerService } from "../serviceapp/proxies/loanofficer.service";
import { LoanOfficer } from "../serviceapp/proxies/loanofficer.model";
import { Person } from "../serviceapp/proxies/person.model";
import { Router, ActivatedRoute, Params } from "@angular/router";

@Component({
    selector: 'app-editloanofficer',
    templateUrl: './editloanofficer.component.html',
    providers: [LoanOfficerService]
})
/** editcustomer component*/
export class EditLoanOfficerComponent implements OnInit {
    editForm: FormGroup;
    editLoanOfficer: LoanOfficer;
    constructor(private formBuilder: FormBuilder,
        private router: Router,
        private loanOfficerService: LoanOfficerService,
        private activatedRoute: ActivatedRoute
     ) { }

ngOnInit(){

    var officerId;

    this.activatedRoute.queryParams.subscribe(params => {
      officerId = params['officerId'];
     });

  this.loanOfficerService.getLoanOfficerById(officerId)
     .subscribe(officer => {

       this.editLoanOfficer = officer;

        this.editForm = this.formBuilder.group({
          applicantId: officer.person.id,
          sssn: officer.person.ssn,
          firstName: officer.person.firstName,
          lastName: officer.person.lastName,
          address: officer.person.address,
          gender: officer.person.gender,
          birthdate: officer.person.birthdate,
          email: officer.person.emailAddress,
          phonenumber: officer.person.phoneNumber,
          });
     });
}

onSubmit() {

    //INFO: Only submit the new customer if the form is valid.  
    if (this.editForm.valid) {

      //INFO: Map the form data into the customer object.
      let updatedloanofficer = new LoanOfficer();
    let updatedperson = new Person();

      updatedperson.id = this.editForm.value.id;
      updatedperson.ssn = this.editForm.value.ssn;
      updatedperson.firstName = this.editForm.value.firstName;
      updatedperson.lastName = this.editForm.value.lastName;
      updatedperson.address = this.editForm.value.address || '';
      updatedperson.gender = this.editForm.value.gender || '';
      updatedperson.birthdate = this.editForm.value.birthdate;
      updatedperson.emailAddress = this.editForm.value.email || '';
      updatedperson.phoneNumber = this.editForm.value.phonenumber || '';
      updatedloanofficer.person = updatedperson;
      updatedloanofficer.mortgages = [];
      updatedloanofficer.updatedBy = "admin";

    //INFO: Clear out old messages.
    document.getElementById("rulemessages").innerHTML = "";

      this.loanOfficerService.updateLoanOfficer(updatedloanofficer)
      .subscribe(result => {
        if (result != null && Object.values(result).length > 0)
        {
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
      }, ex =>
        {
          //INFO: Standard error handling.  
          alert("Failed to updated the loan officer record: " + ex.status + " " + ex.error);
        }
      );
    }
  }    
}
