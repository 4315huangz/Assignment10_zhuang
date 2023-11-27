import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders  } from '@angular/common/http';
import { MortgageApplicant } from "./mortgageapplicant.model";

// Enable Cross-Origin Requests (CORS) in ASP.NET Core
//https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-3.1#enable-cors-with-cors-middleware
//https://angular.io/guide/http#adding-and-updating-headers
const httpOptions = {
  headers: new HttpHeaders({
    "Access-Control-Allow-Origin": "*"
  })
};

@Injectable()
export class MortgageApplicantService {
  constructor(private http: HttpClient) { }
  baseUrl: string = 'https://localhost:44346/api/MortgageApplicant';


  getMortgageApplicants() {
    return this.http.get<MortgageApplicant[]>(this.baseUrl + '/mortgageApplicants', httpOptions);
  }

  getMortgageApplicantById(id: number) {
    return this.http.get<MortgageApplicant>(this.baseUrl + '/mortgageApplicants/' + id, httpOptions);
  }

  createMortgageApplicant(mortgageApplicant: MortgageApplicant) {
    return this.http.post<MortgageApplicant>(this.baseUrl, mortgageApplicant, httpOptions);
  }

  updateMortgageApplicant(mortgageApplicant: MortgageApplicant) {    
    return this.http.put<MortgageApplicant>(this.baseUrl, mortgageApplicant, httpOptions);
  }

  deleteMortgageApplicant(applicantId: number) {
    return this.http.delete(this.baseUrl + '/' + applicantId, httpOptions);
  }
}
