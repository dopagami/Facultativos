import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Facultativo } from '../models/facultativo';
// import { ENGINE_METHOD_DIGESTS } from 'constants';

@Injectable()
export class FacultativoService {
  _mydata: Observable<Facultativo[]>;
  public element: any = {};
  data: any;
  dataChange: any;
  private serviceUrl = '../../assets/facultativos.json';

  constructor(private http: HttpClient) { }

  getUser(): Observable<Facultativo[]> {
    this._mydata =  this.http.get<Facultativo[]>(this.serviceUrl);
    return this._mydata;
  }

  getFacultativo(id: string): any {
    return this.http.get<Facultativo>(this.serviceUrl + '/' +  id );
  }

  // Método temporal hasta que tengamos el método en el Web API
  getFacultativoTemp(id: number): any {
    this._mydata.subscribe(results => {
      this.element =  results[id];
    });
  }

  getAllPrivilegios(): void {
    this.http.get(this.serviceUrl).subscribe(data => {
      this.dataChange.next(data);
      this.data = data;
    },
      (error: HttpErrorResponse) => {
        console.log(error.name + ' ' + error.message);
      });
  }

}
