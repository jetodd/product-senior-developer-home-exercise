import { Component } from '@angular/core';
import { PersonService } from '../../services/person.service';
import { PersonViewModel } from 'src/app/models/person-view-model';
import { DepartmentService } from 'src/app/services/department.service';
import { DepartmentViewModel } from 'src/app/models/department-view-model';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.scss'],
})
export class PeopleComponent {
  people: PersonViewModel[] = [];
  departments: DepartmentViewModel[] = [];

  constructor(
    private personService: PersonService,
    private departmentService: DepartmentService,
  ) {}

  updatePeople() {
    this.personService.getPeople().subscribe({
      next: (result) => (this.people = result),
      error: (e) => console.error(`Error: ${e}`),
    });
  }

  ngOnInit() {
    this.updatePeople();

    this.departmentService.getDepartments().subscribe({
      next: (result) => (this.departments = result),
      error: (e) => console.error(`Error: ${e}`),
    });
  }
}
