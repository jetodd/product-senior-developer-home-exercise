import { Component } from '@angular/core';
import { PersonService } from '../../services/person.service';
import { PersonViewModel } from 'src/app/models/person-view-model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DepartmentService } from 'src/app/services/department.service';
import { dateValidator } from 'src/app/validators/date-of-birth.validator';
import { DepartmentViewModel } from 'src/app/models/department-view-model';
import * as moment from 'moment-timezone';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.scss']
})
export class PeopleComponent {
  personForm: FormGroup;
  
  people: PersonViewModel[] = [];
  departments: DepartmentViewModel[] = [];

  selectedPersonId: number  = 0;

  constructor(
    private personService: PersonService,
    private departmentService: DepartmentService,
  ) {
    this.personForm = new FormGroup({
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      dateOfBirth: new FormControl('', [Validators.required, dateValidator()]),
      email: new FormControl('', [Validators.required, Validators.email]),
      departmentId: new FormControl('', [Validators.required]),
    },
    {
      updateOn: 'blur',
    }
  );
  }

  submit() {
    const person = this.personForm.getRawValue();

    if (this.selectedPersonId !== 0) {
      this.personService.updatePerson(this.selectedPersonId, person).subscribe(()=>{
        this.updatePeople();
      });
    } else {
      this.personService.addPerson(person).subscribe(()=>{
        this.updatePeople();
      });
    }

    this.clearForm();
  }

  updatePeople() {
    this.personService.getPeople().subscribe({
      next: (result) => this.people = result,
      error: (e) => console.error(`Error: ${e}`)
    });
  }

  ngOnInit() {
    this.updatePeople();

    this.departmentService.getDepartments().subscribe({
      next: (result) =>  this.departments = result,
      error: (e) => console.error(`Error: ${e}`)
    });
  }

  getPersonById(id: number): void {
    this.personService.getById(id).subscribe({
      next: (result) => {
        console.info(`User returned: ${JSON.stringify(result)}`)
      },
      error: (e) => console.error(`Error: ${e}`)
    });
  }

  handleSelect(selectedPerson: PersonViewModel) {
    this.personForm.setValue({
      firstName: selectedPerson.firstName, 
      lastName: selectedPerson.lastName,
      dateOfBirth: moment(selectedPerson.dateOfBirth).format('YYYY-MM-DD'),
      email: selectedPerson.email,
      departmentId: selectedPerson.departmentId
    });

    this.selectedPersonId = selectedPerson.id;
  }

  clearForm() {
    this.selectedPersonId = 0;
    this.personForm.reset();
  }

  get firstName() {
    return this.personForm.get('firstName')
  }

  get lastName() {
    return this.personForm.get('lastName')
  }

  get departmentId() {
    return this.personForm.get('departmentId')
  }

  get dateOfBirth() {
    return this.personForm.get('dateOfBirth')
  }

  get email() {
    return this.personForm.get('email')
  }
}
