import { DatePipe } from '@angular/common';
import { Component, Input } from '@angular/core';
import { DepartmentViewModel } from 'src/app/models/department-view-model';
import { PersonViewModel } from 'src/app/models/person-view-model';
import { DepartmentFilterPipe } from 'src/app/pipes/department-filter.pipe';
import { SharedPersonService } from 'src/app/services/shared-person.service';

@Component({
  selector: 'app-card',
  standalone: true,
  imports: [DatePipe, DepartmentFilterPipe],
  templateUrl: './card.component.html',
  styleUrl: './card.component.scss'
})
export class CardComponent {
  @Input() person: PersonViewModel;
  @Input() departments: DepartmentViewModel[] = [];

  constructor(private sharedPersonService: SharedPersonService) {
  }

  sharePerson(person: PersonViewModel): void {
    this.sharedPersonService.person.next(person);
  }
}
