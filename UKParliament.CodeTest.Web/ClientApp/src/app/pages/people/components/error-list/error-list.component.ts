import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-error-list',
  standalone: true,
  imports: [],
  templateUrl: './error-list.component.html',
  styleUrl: './error-list.component.scss',
})
export class ErrorListComponent {
  @Input() errors: string[] = [];
}
