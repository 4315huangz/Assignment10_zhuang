import { Component, Inject } from '@angular/core';
import { MortgageApplicant } from "../serviceapp/proxies/mortgageapplicant.model";
import { MortgageApplicantService } from "../serviceapp/proxies/mortgageapplicant.service";
import { Headers, Http, RequestOptions } from '@angular/http';

@Component({
  selector: 'app-list-mortgageapplicant',
  templateUrl: './listmortgageapplicant.component.html',
  providers: [MortgageApplicantService]
})
export class ListMortgageApplicantComponent {
  public applicants: MortgageApplicant[];

  constructor(private mortgageApplicantService: MortgageApplicantService) {  
   }

   accessToken: string;

  ngOnInit() {   
      
    this.mortgageApplicantService.getMortgageApplicants().subscribe(result => {
      this.applicants = result;
    }, ex => alert(ex.error));
  }
  }

