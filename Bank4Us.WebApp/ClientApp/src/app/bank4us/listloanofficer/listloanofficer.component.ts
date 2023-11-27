import { Component, Inject } from '@angular/core';
import { LoanOfficer } from "../serviceapp/proxies/loanofficer.model";
import { LoanOfficerService } from "../serviceapp/proxies/loanofficer.service";
import { Headers, Http, RequestOptions } from '@angular/http';

@Component({
  selector: 'app-list-loanofficer',
  templateUrl: './listloanofficer.component.html',
  providers: [LoanOfficerService]
})
export class ListLoanOfficerComponent {
  public officers: LoanOfficer[];

  constructor(private loanOfficerService: LoanOfficerService) {  
   }

   accessToken: string;

  ngOnInit() {   
      
    this.loanOfficerService.getLoanOfficers().subscribe(result => {
      this.officers = result;
    }, ex => alert(ex.error));
  }
  }

