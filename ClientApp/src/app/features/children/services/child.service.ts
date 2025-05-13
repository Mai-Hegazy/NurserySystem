import { Child } from './../models/child.model';
import { environment } from './../../../../environments/environment.prod';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ChildService {

  private apiUrl = `${environment.apiUrl}/child`;
  
  constructor(private http: HttpClient) { }

  getChildren(): Observable<Child[]> {
    return this.http.get<Child[]>(`${this.apiUrl}`);
  }

  getById(id: number): Observable<Child> {
    return this.http.get<Child>(`${this.apiUrl}/${id}`);
  }

  create(child: Child): Observable<Child> {
    return this.http.post<Child>(this.apiUrl, child);
  }

  update(child: Child): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${child.id}`, child);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

}
