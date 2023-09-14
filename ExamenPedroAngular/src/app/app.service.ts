import { HttpClient, HttpHeaders, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError, tap, throwError } from "rxjs";

import { IPersona } from "./persona";

@Injectable({
  providedIn: 'root'
})

export class AppService {
  private conversorUrl = 'https://3enrayacodecurrencyconverter.azurewebsites.net/api/Conversor';
  private token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoibW9jaCIsImp0aSI6IjhiMTVkODlhLWU1YjUtNDM4Yi1iMTNhLWEzODU5NmNhYWZlOCIsImV4cCI6MTY5NTg5MjQ5MiwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo0MjAwIn0.xHkxQ1cqrOW8iK156IJSKRTuTQBs-vGbJYzoeAIxDyI"

  constructor(private http: HttpClient) { }

  // postConversion(body: IPeticionConversion): Observable<IResultadoConversion> {
  //   let headers = new HttpHeaders().set('Authorization', `Bearer ${this.token}`);
  //   return this.http.post<IResultadoConversion>(this.conversorUrl, body, { headers }).pipe(
  //       tap(data => console.log('All', JSON.stringify(data))),
  //       catchError(this.handleError)
  //   );
  // }

  postPersona(body: IPersona): Observable<void> {
    return this.http.post<void>("https://localhost:7036/api/personas/registrarUsuario", body).pipe(
      tap(data => console.log('All', JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  getPersonas(): Observable<IPersona[]> {
    return this.http.get<IPersona[]>("https://localhost:7036/api/personas/mayoresDe21").pipe(
      tap(data => console.log('All', JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  private handleError(err: HttpErrorResponse) {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(() => errorMessage);
  }
}
