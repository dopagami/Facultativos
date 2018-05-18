import { Injectable, Optional } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Privilegio } from '../models/privilegio.model';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';
import { LoadedRouterConfig } from '@angular/router/src/config';
import { observableToBeFn } from 'rxjs/testing/TestScheduler';
import 'rxjs/add/operator/finally';

// Variables Globales
import * as myGlobals from '../../shared/globals';
import { KeycloakService } from 'keycloak-angular';

@Injectable()
export class PrivilegioService {

  // Url que devuvle un JSON... cambiar por nuestra API
  // private readonly API_URL = 'https://api.github.com/repos/angular/angular/issues';


  // JSON EN LOCAL
  // private readonly API_URL = "./assets/privilegios.json";
  // private readonly API_URL = 'http://mk22788p/api/Privilegios';
  http: any;
  dataChange: BehaviorSubject<Privilegio[]> = new BehaviorSubject<Privilegio[]>([]);

  // Property que guarda  temporalmente el data de los diálogos
  public dialogData: any;

  constructor(private httpClient: HttpClient,
              private keycloak?: KeycloakService) { }

  get data(): Privilegio[] {
    return this.dataChange.value;
  }

  getDialogData() {
    return this.dialogData;
  }

  // setHeader('Access-Control-Allow-Origin', 'http://localhost:8888');
  /** CRUD METHODS */
  getAllPrivilegios(): void {
    // const headers = new HttpHeaders().set('Content-Type', 'application/json; charset=UTF-8');
    this.httpClient.get<Privilegio[]>(myGlobals.API_URL_ROOT + '/Privilegios').subscribe(data => {
      this.dataChange.next(data);
    },
      (error: HttpErrorResponse) => {
        console.log(error.name + ' ' + error.message);
      });
  }

  getPrivilegios(): Observable<Privilegio[]> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json; charset=UTF-8');
    return this.httpClient.get<Privilegio[]>(myGlobals.API_URL_ROOT + '/Privilegios', { headers: headers }).map(res => res);
  }


  // AÃ±adir privilegio (almacena de manera temportal (para pruebas)
  addPrivilegiotemp(privilegio: Privilegio): void {
    this.dialogData = privilegio;
  }

  // Añade un privilegio. Devuleve un Observable (ADD, POST METHOD)
  addPrivilegio(privilegio: Privilegio): Observable<any> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json; charset=UTF-8');

    return this.httpClient.post<any>(myGlobals.API_URL_ROOT + '/Privilegios', privilegio, { headers: headers })
      .map(res => res);
  }


  // DELETE, DELETE METHOD
  deleteItem(id: number): Observable<any> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json; charset=UTF-8');

    return this.httpClient.delete(myGlobals.API_URL_ROOT + '/Privilegios/' + id, { headers: headers })
      .map(res => res);
  }

  // UPDATE, PUT METHOD
  updatePrivilegio(privilegio: Privilegio): Observable<any> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json; charset=UTF-8');

    return this.httpClient.put<any>(myGlobals.API_URL_ROOT + '/Privilegios/' + privilegio.IDPrivilegio, privilegio, { headers: headers })
      .map(res => res);
  }
}

