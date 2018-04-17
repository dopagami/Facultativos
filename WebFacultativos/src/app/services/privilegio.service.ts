import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Privilegio } from '../models/privilegio.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';
import { LoadedRouterConfig } from '@angular/router/src/config';
import { observableToBeFn } from 'rxjs/testing/TestScheduler';
import 'rxjs/add/operator/finally';

// import { Headers, RequestOptions } from '@angular/http';

@Injectable()
export class PrivilegioService {

  //private headers = new Headers({ 'Content-Type': 'application/json' });

  http: any;

  // Url que devuvle un JSON... cambiar por nuestra API
  // private readonly API_URL = 'https://api.github.com/repos/angular/angular/issues';


  // JSON EN LOCAL
  // private readonly API_URL = "./assets/privilegios.json";
  private readonly API_URL = "http://mk22788p/api/Privilegios";

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
      debugger;
      this.dataChange.next(data);
    },
      (error: HttpErrorResponse) => {
        console.log(error.name + ' ' + error.message);
      });
  }

  // AÃ±adir privilegio (almacena de manera temportal)
  addPrivilegiotemp(privilegio: Privilegio): void {
    this.dialogData = privilegio;
  }


  // Añade un privilegio. Devuleve un Observable (ADD, POST METHOD)
  addPrivilegio (privilegio: Privilegio): Observable<any>{
    debugger;
    let headers = new HttpHeaders().set('Content-Type', 'application/json; charset=UTF-8');
    return this.httpClient.post<any>(this.API_URL, privilegio, {headers:headers}).map(res=>res);
  }

  // DELETE METHOD
  deleteItem(id: number): void {
    this.httpClient.delete(this.API_URL + id).subscribe(data => {
      console.log(data['']);
      //this.toasterService.showToaster('Successfully deleted', 3000);
    },
      (err: HttpErrorResponse) => {
        //this.toasterService.showToaster('Error occurred. Details: ' + err.name + ' ' + err.message, 8000);
      }
    );
  }

  // UPDATE, PUT METHOD
  // updatePrivilegio(kanbanItem: Privilegio): void {
  //   this.httpClient.put(this.API_URL + kanbanItem.IDPrivilegio, kanbanItem).subscribe(data => {
  //       //this.dialogData = kanbanItem;
  //       //this.toasterService.showToaster('Successfully edited', 3000);
  //     },
  //     (err: HttpErrorResponse) => {
  //       //this.toasterService.showToaster('Error occurred. Details: ' + err.name + ' ' + err.message, 8000);
  //     }
  //   );
  // }

}

