import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Privilegio } from '../models/privilegio.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';
// const httpOptions = {
//   headers: new HttpHeaders({
//     'Content-Type':  'application/json',
//     'Authorization': 'my-auth-token'
//   })
// };

@Injectable()
export class PrivilegioService {


  
  http: any;
  privilegio: Privilegio[];
  // Url que devuvle un JSON... cambiar por nuestra API
  // private readonly API_URL = 'https://api.github.com/repos/angular/angular/issues';


  // JSON EN LOCAL
  // private readonly API_URL = "./assets/privilegios.json";
  private readonly API_URL = "http://mk22788p/api/Privilegios";
  
  dataChange: BehaviorSubject<Privilegio[]> = new BehaviorSubject<Privilegio[]>([]);

  // Property que guarda  temporalmente el data de los diÃ¡logos
  dialogData: any;
  privilegios: Privilegio[];

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
        console.log(data);
      },
      (error: HttpErrorResponse) => {
      console.log (error.name + ' ' + error.message);
      });
  }


  // AÃ±adir privilegio
  // addPrivilegio (privilegio: Privilegio): void {
  //   this.dialogData = privilegio;    
  // }


 

  // ADD, POST METHOD
   addPrivilegio(privilegio: Privilegio): any {
    

    // let cluster: Privilegio = {
    //   IDPrivilegio: 100,
    //   Valor: "G",
    //   Descripcion: 'nuevo cluster'
    // };

    

    this.httpClient.post(this.API_URL, privilegio).subscribe(data => {
      
      this.dialogData = privilegio;
      //this.toasterService.showToaster('Successfully added', 3000);
      alert("GrabaciÃ³n correcta");
      },
      (err: HttpErrorResponse) => {
      //this.toasterService.showToaster('Error occurred. Details: ' + err.name + ' ' + err.message, 8000);
      alert(err.name + ' ' + err.message);
    });
   }


    // UPDATE, PUT METHOD
    updatePrivilegio(kanbanItem: Privilegio): void {
      this.httpClient.put(this.API_URL + kanbanItem.IDPrivilegio, kanbanItem).subscribe(data => {
          this.dialogData = kanbanItem;
          //this.toasterService.showToaster('Successfully edited', 3000);
        },
        (err: HttpErrorResponse) => {
          //this.toasterService.showToaster('Error occurred. Details: ' + err.name + ' ' + err.message, 8000);
        }
      );
    }

  
  // addPrivilegio(privilegio:Privilegio): Observable<Privilegio> {
          
    
  //   //let headers = new Headers({ 'Content-Type': 'application/json' });
  //         //let options = new RequestOptions({ headers: headers });
  //         return this.httpClient.post(this.API_URL, privilegio)
  //                    .map(this.extractData)
  //                    .catch(this.handleErrorObservable);
  //     }


      // private extractData(res: Response) {
      //   let body = res.json();
      //         return body || {};
      //     }
      //     private handleErrorObservable (error: Response | any) {
      //   console.error(error.message || error);
      //   return Observable.throw(error.message || error);
      //     }

}

