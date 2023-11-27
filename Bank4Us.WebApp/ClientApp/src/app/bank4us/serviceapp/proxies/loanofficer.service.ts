import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders  } from '@angular/common/http';
import { LoanOfficer } from "./loanofficer.model";

// Enable Cross-Origin Requests (CORS) in ASP.NET Core
//https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-3.1#enable-cors-with-cors-middleware
//https://angular.io/guide/http#adding-and-updating-headers
const httpOptions = {
  headers: new HttpHeaders({
    "Access-Control-Allow-Origin": "*"
  })
};

@Injectable()
export class LoanOfficerService {
  constructor(private http: HttpClient) { }
  baseUrl: string = 'https://localhost:44346/api/LoanOfficer';


  getLoanOfficers() {
    return this.http.get<LoanOfficer[]>(this.baseUrl + '/loanOfficers', httpOptions);
  }

  getLoanOfficerById(officerId: number) {
    return this.http.get<LoanOfficer>(this.baseUrl + '/loanOfficers/' + officerId, httpOptions);
  }

  createLoanOfficer(loanOfficer: LoanOfficer) {
    return this.http.post<LoanOfficer>(this.baseUrl, loanOfficer, httpOptions);
  }

  updateLoanOfficer(loanOfficer: LoanOfficer) {    
    return this.http.put<LoanOfficer>(this.baseUrl, loanOfficer, httpOptions);
  }

  deletLoanOfficer(officerId: number) {
    return this.http.delete(this.baseUrl + '/' + officerId, httpOptions);
  }
}
