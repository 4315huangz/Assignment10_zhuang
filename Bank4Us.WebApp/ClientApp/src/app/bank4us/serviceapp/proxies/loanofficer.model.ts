import { Mortgage } from "./mortgage.model";
import { Person } from "./person.model"
export class LoanOfficer {
  officerId: number;
  title: string;
  person: Person;
  mortgages: Mortgage[];
  createdBy: string;
  updatedBy: string;
}
