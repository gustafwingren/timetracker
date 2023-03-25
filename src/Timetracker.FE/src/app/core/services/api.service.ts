import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  constructor(private httpClient: HttpClient) {}

  get<T>(requestUrl: string): Observable<T> {
    return this.httpClient.get<T>(requestUrl);
  }

  post<T>(requestUrl: string, data: any): Observable<T> {
    return this.httpClient.post<T>(requestUrl, data);
  }

  delete<T>(requestUrl: string): Observable<T> {
    return this.httpClient.delete<T>(requestUrl);
  }
}
