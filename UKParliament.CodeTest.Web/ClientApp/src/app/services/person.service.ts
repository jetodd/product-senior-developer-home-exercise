import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PersonViewModel } from '../models/person-view-model';

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  // Below is some sample code to help get you started calling the API
  getById(id: number): Observable<PersonViewModel> {
    return this.http.get<PersonViewModel>(this.baseUrl + `api/person/${id}`)
  }

  getPeople(): Observable<PersonViewModel[]> {
    return this.http.get<PersonViewModel[]>(this.baseUrl + `api/person`)
  }

  addPerson(person: PersonViewModel) {
    this.http.post<PersonViewModel>(this.baseUrl + `api/person`, person)
  }

  updatePerson(person: PersonViewModel) {
    this.http.put<PersonViewModel>(this.baseUrl + `api/person/${person.id}`, person)
  }
}
