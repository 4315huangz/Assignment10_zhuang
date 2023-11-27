import { Mortgage } from "./mortgage.model";
import { Person } from "./person.model"
import {CreditReport } from "./creditreport.model"

export class MortgageApplicant {
  applicantId: number;
  person: Person;
  creditReport: CreditReport;
  mortgages: Mortgage[];
  createdBy: string;
  updatedBy: string;
}
