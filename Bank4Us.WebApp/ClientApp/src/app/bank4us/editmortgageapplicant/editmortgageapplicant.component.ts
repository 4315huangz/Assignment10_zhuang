import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators} from "@angular/forms";
import { MortgageApplicantService } from "../serviceapp/proxies/mortgageapplicant.service";
import { MortgageApplicant } from "../serviceapp/proxies/mortgageapplicant.model";
import { Person } from "../serviceapp/proxies/person.model";
import { Router, ActivatedRoute, Params } from "@angular/router";

@Component({
    selector: 'app-editmortgageapplicant',
    templateUrl: './editmortgageapplicant.component.html',
    providers: [MortgageApplicantService]
})
/** editcustomer component*/
export class EditMortgageApplicantComponent implements OnInit {
    editForm: FormGroup;
    editMortgageApplicant: MortgageApplicant;
    constructor(private formBuilder: FormBuilder,
        private router: Router,
        private mortgageapplicantService: MortgageApplicantService,
        private activatedRoute: ActivatedRoute
     ) { }

ngOnInit(){

    var applicantId;

    this.activatedRoute.queryParams.subscribe(params => {
      applicantId = params['applicantId'];
     });

  this.mortgageapplicantService.getMortgageApplicantById(applicantId)
     .subscribe(applicant => {

        this.editMortgageApplicant = applicant;

        this.editForm = this.formBuilder.group({
          applicantId: applicant.person.id,
          sssn: applicant.person.ssn,
          firstName: applicant.person.firstName,
          lastName: applicant.person.lastName,
          address: applicant.person.address,
          gender: applicant.person.gender,
          birthdate: applicant.person.birthdate,
          email: applicant.person.emailAddress,
          phonenumber: applicant.person.phoneNumber,
          });
     });
}

onSubmit() {

    //INFO: Only submit the new customer if the form is valid.  
    if (this.editForm.valid) {

      //INFO: Map the form data into the customer object.
      let updatedmortgageapplicant = new MortgageApplicant();
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
      updatedmortgageapplicant.person = updatedperson;
      updatedmortgageapplicant.mortgages = [];
      updatedmortgageapplicant.updatedBy = "admin";

    //INFO: Clear out old messages.
    document.getElementById("rulemessages").innerHTML = "";

      this.mortgageapplicantService.updateMortgageApplicant(updatedmortgageapplicant)
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
          this.router.navigate(['listmortgageapplicant']);
        }        
      }, ex =>
        {
          //INFO: Standard error handling.  
          alert("Failed to updated the mortgage applicant record: " + ex.status + " " + ex.error);
        }
      );
    }
  }    
}
