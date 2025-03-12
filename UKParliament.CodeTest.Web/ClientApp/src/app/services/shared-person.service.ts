import { Injectable } from '@angular/core';
import { BehaviorSubject, ReplaySubject } from 'rxjs';
import { PersonViewModel } from '../models/person-view-model';

@Injectable({
  providedIn: 'root'
})
export class SharedPersonService {
  person: ReplaySubject<PersonViewModel> = new ReplaySubject();
}
