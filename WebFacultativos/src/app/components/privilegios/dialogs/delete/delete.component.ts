import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material';
import {Component, Inject} from '@angular/core';
import { PrivilegioService } from '../../../../services/privilegio.service';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
// Variables Globales
import * as myGlobals from '../../../../../shared/globals';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent {

  constructor(public dialogRef: MatDialogRef<DeleteComponent>,
              @Inject(MAT_DIALOG_DATA) public data: any,
              public dataService: PrivilegioService,
              public global: myGlobals.Globals) { }

  onNoClick(): void {
    this.dialogRef.close('1');
  }

  confirmDelete(): void {
    // this.dataService.deleteItem(this.data.id);
    // this.dialogRef.close(this.data);

    this.dataService.deleteItem(this.data.id).subscribe(res => {
      // Para agregar, sólo anadimos una nueva fila en el DataService
      this.dialogRef.close(res);
    }, (err: HttpErrorResponse) => {
        this.global.errorCodes(err.status);
    });

  }
}