import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Privilegio } from '../models/privilegio.model';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';
import { LoadedRouterConfig } from '@angular/router/src/config';
import { observableToBeFn } from 'rxjs/testing/TestScheduler';
import 'rxjs/add/operator/finally';
import { Globals } from '../../shared/globals';

// import { Headers, RequestOptions } from '@angular/http';

@Injectable()
export class PrivilegioService {

  // Url que devuvle un JSON... cambiar por nuestra API
  // private readonly API_URL = 'https://api.github.com/repos/angular/angular/issues';


  // JSON EN LOCAL
  // private readonly API_URL = "./assets/privilegios.json";
  private readonly API_URL = 'http://mk22788p/api/Privilegios';
  http: any;
  dataChange: BehaviorSubject<Privilegio[]> = new BehaviorSubject<Privilegio[]>([]);

  // Property que guarda  temporalmente el data de los diálogos
  public dialogData: any;
  // privilegios: Privilegio[];

  constructor(private httpClient: HttpClient) { }

  get data(): Privilegio[] {
    return this.dataChange.value;
  }

  getDialogData() {
    return this.dialogData;
  }


  /** CRUD METHODS */
  getAllPrivilegios(): void {
    this.httpClient.get<Privilegio[]>(this.API_URL).subscribe(data => {
      this.dataChange.next(data);
    },
      (error: HttpErrorResponse) => {
        console.log(error.name + ' ' + error.message);
      });
  }

  // AÃ±adir privilegio (almacena de manera temportal (para pruebas)
  addPrivilegiotemp(privilegio: Privilegio): void {
    this.dialogData = privilegio;
  }

  // Añade un privilegio. Devuleve un Observable (ADD, POST METHOD)
  addPrivilegio(privilegio: Privilegio): Observable<any> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json; charset=UTF-8');

    return this.httpClient.post<any>(this.API_URL, privilegio, { headers: headers })
      .map(res => res);
  }


  // DELETE, DELETE METHOD
  deleteItem(id: number): Observable<any> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json; charset=UTF-8');

    return this.httpClient.delete(this.API_URL + '/' + id, { headers: headers })
      .map(res => res);
  }

  // UPDATE, PUT METHOD
  updatePrivilegio(privilegio: Privilegio): Observable<any> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json; charset=UTF-8');

    return this.httpClient.put<any>(this.API_URL + '/' + privilegio.IDPrivilegio, privilegio, { headers: headers })
      .map(res => res);
  }
}

