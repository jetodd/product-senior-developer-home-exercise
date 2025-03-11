import { Component, EventEmitter, Input, Output, SimpleChanges } from '@angular/core';
import { PersonService } from '../../services/person.service';
import { PersonViewModel } from 'src/app/models/person-view-model';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DepartmentService } from 'src/app/services/department.service';
import { dateValidator } from 'src/app/validators/date-of-birth.validator';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.scss']
})
export class PeopleComponent {
  //@Input() person: PersonViewModel = {firstName = '', lastName = ''};
  @Output() submitted = new EventEmitter<PersonViewModel>();
  personForm: FormGroup;
  
  people: PersonViewModel[] = [];
  departments: string[] = [];

  constructor(
    private personService: PersonService,
    private departmentService: DepartmentService,
    private formBuilder: FormBuilder
  ) {
    this.getPersonById(1);

    this.personForm = new FormGroup({
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      dateOfBirth: new FormControl('', [Validators.required, dateValidator()]),
      department: new FormControl('', [Validators.required]),
    });
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes.medal?.currentValue) {
      //this.personForm?.patchValue(this.person);
    }
  }

  submit() {
    const person = this.personForm.getRawValue();
    this.submitted.emit(this.personForm.getRawValue());
    
    this.personForm.reset();
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
      next: (result) => this.departments = result,
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

  get firstName() {
    return this.personForm.get('firstName');
  }

  get lastName() {
    return this.personForm.get('lastName');
  }

  get department() {
    return this.personForm.get('department');
  }

  get dateOfBirth() {
    return this.personForm.get('dateOfBirth');
  }
}
