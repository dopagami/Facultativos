import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

// Models
import { Cuestionario } from '../models/cuestionario';
// tslint:disable-next-line:import-blacklist
import { Observable } from 'rxjs';
import { GlobalPositionStrategy } from '@angular/cdk/overlay';
import * as myGlobals from '../../shared/globals';


@Injectable()
export class CuestionarioService {

  constructor(private httpClient: HttpClient) { }

  // get Cuestionario
  getCuestionario(id: number): Observable<Cuestionario[]> {
    return this.httpClient.get<Cuestionario[]>(myGlobals.API_URL_ROOT + '/Cuestionarios/' + id);
  }

  getDetail():Observable<any> {
    return this.httpClient.get<any[]>('http://facultativosapi.ibermatica.com/api/CuestionariosFacultativos/1/1')
  }

}
