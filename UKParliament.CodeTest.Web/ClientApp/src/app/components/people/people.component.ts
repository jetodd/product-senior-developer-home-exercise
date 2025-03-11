import { Component } from '@angular/core';
import { PersonService } from '../../services/person.service';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.scss']
})
export class PeopleComponent {
  constructor(private personService: PersonService) {
    this.getPersonById(1);
  }

  getPersonById(id: number): void {
    this.personService.getById(id).subscribe({
      next: (result) => console.info(`User returned: ${JSON.stringify(result)}`),
      error: (e) => console.error(`Error: ${e}`)
    });
  }
}
