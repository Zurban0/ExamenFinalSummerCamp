import { HttpClient, HttpHeaders, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError, tap, throwError } from "rxjs";

import { IPersona } from "./persona";
import { IPersonaForm } from "./persona-form";

@Injectable({
  providedIn: 'root'
})

export class AppService {
  constructor(private http: HttpClient) { }

  postPersona(body: IPersonaForm): Observable<void> {
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
