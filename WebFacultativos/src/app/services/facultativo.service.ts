import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Facultativo } from '../models/facultativo';
// Variables Globales
import * as myGlobals from '../../shared/globals';
import { observableToBeFn } from 'rxjs/testing/TestScheduler';

@Injectable()
export class FacultativoService {
  _mydata: Observable<Facultativo[]>;
  public element: any = {};
  public facultativo: Facultativo[];
  data: any;
  dataChange: any;
  private serviceUrl = '../../assets/facultativos.json';

  constructor(private http: HttpClient) { }

  getFacultativo(id: string, dpto: string): Observable<Facultativo> {
    return this.http.get<Facultativo>(myGlobals.API_URL_ROOT + '/Facultativos/' + id + '/' + dpto);
  }

  getFacultativos(): Observable<Facultativo[]> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json; charset=UTF-8');
    this._mydata = this.http.get<Facultativo[]>(myGlobals.API_URL_ROOT + '/Facultativos', { headers: headers });
    return this._mydata;
  }

  // Método temporal hasta que tengamos el método en el Web API
  getFacultativoTemp(id: number): any {
    this._mydata.subscribe(results => {
      this.element = results[id];
    });
  }
}
