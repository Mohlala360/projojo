import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Person } from '../models/person';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  public readonly environment: string = environment.apiUrl;
  public constructor(private http: HttpClient) {  
  }

  public GetPersons(): Observable<Person[]> {
    return this.http.get<Person[]>(`${this.environment}/todos`);
  }

  public GetPerson(id: string): Observable<Person> {
    return this.http.get<Person>(`${this.environment}/todos/${id}`);
  }

  public UpdatePerson(id: string, person: Person): Observable<Person> {
    return this.http.put<Person>(`${this.environment}/todos/${id}`, person);
  }

  public CreatePerson(person: Person): Observable<Person> {
    return this.http.post<Person>(`${this.environment}/todos`, person);
  }
}
