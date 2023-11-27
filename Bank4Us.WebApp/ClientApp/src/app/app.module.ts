import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ListMortgageApplicantComponent } from './bank4us/listmortgageapplicant/listmortgageapplicant.component';
import { AddMortgageApplicantComponent } from './bank4us/addmortgageapplicant/addmortgageapplicant.component';
import { EditMortgageApplicantComponent } from './bank4us/editmortgageapplicant/editmortgageapplicant.component';
import { ListLoanOfficerComponent } from './bank4us/listloanofficer/listloanofficer.component';
import { AddLoanOfficerComponent } from './bank4us/addloanofficer/addloanofficer.component';
import { EditLoanOfficerComponent } from './bank4us/editloanofficer/editloanofficer.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ListMortgageApplicantComponent,
    AddMortgageApplicantComponent,
    EditMortgageApplicantComponent,
    ListLoanOfficerComponent,
    AddLoanOfficerComponent,
    EditLoanOfficerComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'listmortgageapplicant', component: ListMortgageApplicantComponent },
      { path: 'addmortgageapplicant', component: AddMortgageApplicantComponent },
      { path: 'editmortgageapplicant', component: EditMortgageApplicantComponent },
      { path: 'listloanofficer', component: ListLoanOfficerComponent },
      { path: 'addloanofficer', component: AddLoanOfficerComponent },
      { path: 'editloanofficer', component: EditLoanOfficerComponent }

    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
