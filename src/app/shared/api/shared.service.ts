import { Injectable } from '@angular/core';
import { Observable } from 'rxjs'; 
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Sport } from '../models/sport';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  public readonly environment: string = environment.apiUrl;
  public constructor(private http: HttpClient) {  
  }

  public GetSports(): Observable<Sport[]> {
    return this.http.get<Sport[]>(`${this.environment}/sport`);
  }
}
