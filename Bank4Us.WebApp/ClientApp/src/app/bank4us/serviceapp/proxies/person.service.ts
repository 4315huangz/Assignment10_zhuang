import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders  } from '@angular/common/http';
import { Person } from "./person.model";

// Enable Cross-Origin Requests (CORS) in ASP.NET Core
//https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-3.1#enable-cors-with-cors-middleware
//https://angular.io/guide/http#adding-and-updating-headers
const httpOptions = {
  headers: new HttpHeaders({
    "Access-Control-Allow-Origin": "*"
  })
};

@Injectable()
export class PersonService {
  constructor(private http: HttpClient) { }
  baseUrl: string = 'https://localhost:44346/api/Person';


  getPersons() {
    return this.http.get<Person[]>(this.baseUrl + '/persons', httpOptions);
  }

  getPersonById(id: number) {
    return this.http.get<Person>(this.baseUrl + '/persons/' + id, httpOptions);
  }

  createPerson(person: Person) {
    return this.http.post<Person>(this.baseUrl, person, httpOptions);
  }

  updatePerson(person: Person) {    
    return this.http.put<Person>(this.baseUrl, person, httpOptions);
  }

  deletePerson(id: number) {
    return this.http.delete(this.baseUrl + '/' + id, httpOptions);
  }
}
