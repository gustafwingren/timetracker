import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, map, Observable, throwError } from 'rxjs';
import { ProblemDetailsResponse } from '../models/problem-details-response';
import { ErrorOrResponse } from '../models/error-or-response';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  constructor(private httpClient: HttpClient) {}

  get<T>(requestUrl: string): Observable<T> {
    return this.httpClient
      .get<ErrorOrResponse<T>>(requestUrl)
      .pipe(map(this.mapResponse), catchError(this.handleError));
  }

  post<T>(requestUrl: string, data: any): Observable<T> {
    return this.httpClient
      .post<ErrorOrResponse<T>>(requestUrl, data)
      .pipe(map(this.mapResponse), catchError(this.handleError));
  }

  put<T>(requestUrl: string, data: any): Observable<T> {
    return this.httpClient
      .put<ErrorOrResponse<T>>(requestUrl, data)
      .pipe(map(this.mapResponse), catchError(this.handleError));
  }

  delete<T>(requestUrl: string): Observable<T> {
    return this.httpClient
      .delete<ErrorOrResponse<T>>(requestUrl)
      .pipe(map(this.mapResponse), catchError(this.handleError));
  }

  mapResponse<T>(response: ErrorOrResponse<T>) {
    if (response.isError) {
      throwError(() => new Error(response.firstError.description));
    }

    return response.value;
  }

  handleError(errorResponse: HttpErrorResponse) {
    if (!(errorResponse.error as ProblemDetailsResponse).type) {
      return throwError(() => errorResponse.message);
    }
    const problemDetails = errorResponse.error as ProblemDetailsResponse;

    const handleErrResponse = {
      status: problemDetails.status,
      errorText: problemDetails.title,
      response: [] as { field: string; error: string }[],
    };

    if (problemDetails.status == 400) {
      // reduce dictionary to an array of errors
      const errors = Object.entries(problemDetails.errors).reduce(
        (previousValue, cur) => {
          for (const err of cur[1]) {
            previousValue.push({
              field: cur[0],
              error: err,
            });
          }

          return previousValue;
        },
        [] as { field: string; error: string }[]
      );

      handleErrResponse.response = errors;
    }

    return throwError(() => handleErrResponse);
  }
}
