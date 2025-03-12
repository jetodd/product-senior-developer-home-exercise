import { Component, EventEmitter, Input, Output } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import * as moment from 'moment';
import { DepartmentViewModel } from 'src/app/models/department-view-model';
import { PersonViewModel } from 'src/app/models/person-view-model';
import { PersonService } from 'src/app/services/person.service';
import { SharedPersonService } from 'src/app/services/shared-person.service';
import { dateValidator } from 'src/app/validators/date-of-birth.validator';
import { ErrorListComponent } from '../error-list/error-list.component';

@Component({
  selector: 'app-person-form',
  standalone: true,
  imports: [ReactiveFormsModule, ErrorListComponent],
  templateUrl: './person-form.component.html',
  styleUrl: './person-form.component.scss',
})
export class PersonFormComponent {
  @Output() personUpdated = new EventEmitter<string>();
  @Input() selectedPerson: PersonViewModel;
  @Input() departments: DepartmentViewModel[] = [];

  personForm: FormGroup;

  selectedPersonId: number = 0;
  errors: string[] = [];

  constructor(
    private personService: PersonService,
    private sharedPersonService: SharedPersonService,
  ) {
    this.personForm = new FormGroup(
      {
        firstName: new FormControl('', [Validators.required]),
        lastName: new FormControl('', [Validators.required]),
        dateOfBirth: new FormControl('', [
          Validators.required,
          dateValidator(),
        ]),
        email: new FormControl('', [Validators.required, Validators.email]),
        departmentId: new FormControl('', [Validators.required]),
      },
      {
        updateOn: 'blur',
      },
    );
  }

  ngOnInit(): void {
    this.sharedPersonService.person.subscribe((person) => {
      this.personForm.setValue({
        firstName: person.firstName,
        lastName: person.lastName,
        dateOfBirth: moment(person.dateOfBirth).format('YYYY-MM-DD'),
        email: person.email,
        departmentId: person.departmentId,
      });

      this.selectedPersonId = person.id;
    });
  }

  clearForm() {
    this.selectedPersonId = 0;
    this.personForm.reset();
    this.errors = [];
  }

  submit() {
    const person = this.personForm.getRawValue();

    if (this.selectedPersonId !== 0) {
      this.personService.updatePerson(this.selectedPersonId, person).subscribe({
        next: () => {
          this.personUpdated.emit();
          this.clearForm();
        },
        error: (e) => {
          this.errors = e.error;
        },
      });
    } else {
      this.personService.addPerson(person).subscribe({
        next: () => {
          this.personUpdated.emit();
          this.clearForm();
        },
        error: (e) => {
          this.errors = e.error;
        },
      });
    }
  }

  get firstName() {
    return this.personForm.get('firstName');
  }

  get lastName() {
    return this.personForm.get('lastName');
  }

  get departmentId() {
    return this.personForm.get('departmentId');
  }

  get dateOfBirth() {
    return this.personForm.get('dateOfBirth');
  }

  get email() {
    return this.personForm.get('email');
  }
}
