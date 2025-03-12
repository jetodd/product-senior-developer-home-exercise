import { Component } from '@angular/core';
import { PersonService } from '../../services/person.service';

@Component({
  selector: 'app-exercise',
  templateUrl: './exercise.component.html',
  styleUrls: ['./exercise.component.scss'],
})
export class ExerciseComponent {
  constructor(private personService: PersonService) {
    this.getPersonById(1);
  }

  getPersonById(id: number): void {
    this.personService.getById(id).subscribe({
      next: (result) =>
        console.info(`User returned: ${JSON.stringify(result)}`),
      error: (e) => console.error(`Error: ${e}`),
    });
  }
}
