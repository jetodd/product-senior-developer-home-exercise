import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
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
    const data = JSON.stringify(person)
    let headers = new HttpHeaders({'Content-Type': 'application/json'})

    return this.http.post<number>(this.baseUrl + `api/person`, data, {headers})
  }

   updatePerson(id: number, person: PersonViewModel) {
    person.id = id;
    const data = JSON.stringify(person)
    let headers = new HttpHeaders({'Content-Type': 'application/json'})

    return this.http.put<PersonViewModel>(this.baseUrl + `api/person/${id}`, data, { headers })
  }
}
