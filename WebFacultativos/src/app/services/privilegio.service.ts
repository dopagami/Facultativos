import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Privilegio } from '../models/privilegio.model';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Injectable()
export class PrivilegioService {

  // Url que devuvle un JSON... cambiar por nuestra API
  // private readonly API_URL = 'https://api.github.com/repos/angular/angular/issues';


  // JSON EN LOCAL
  private readonly API_URL = "./assets/privilegios.json";
  // private readonly API_URL = "http://localhost:49729/api/Privilegios";
  
  dataChange: BehaviorSubject<Privilegio[]> = new BehaviorSubject<Privilegio[]>([]);

  // Property que guarda  temporalmente el data de los diálogos
  dialogData: any;

  constructor (private httpClient: HttpClient) {}

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
      console.log (error.name + ' ' + error.message);
      });
  }

  // Añadir privilegio
  addPrivilegio (privilegio: Privilegio): void {
    this.dialogData = privilegio;
  }

   // ADD, POST METHOD
  //  addPrivilegio(privilegio: Privilegio): void {
  //   this.httpClient.post(this.API_URL, privilegio).subscribe(data => {
  //     this.dialogData = privilegio;
  //     this.toasterService.showToaster('Successfully added', 3000);
  //     },
  //     (err: HttpErrorResponse) => {
  //     this.toasterService.showToaster('Error occurred. Details: ' + err.name + ' ' + err.message, 8000);
  //   });
  //  }

}
