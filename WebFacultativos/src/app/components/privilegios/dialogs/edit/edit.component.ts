import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { Component, Inject } from '@angular/core';
import { PrivilegioService } from '../../../../services/privilegio.service';
import { FormControl, Validators } from '@angular/forms';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
// Variables Globales
import * as myGlobals from '../../../../../shared/globals';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent {
  displayedColumns = ['valor', 'descripcion', 'actions'];

  constructor(public dialogRef: MatDialogRef<EditComponent>,
              @Inject(MAT_DIALOG_DATA) public data: any,
              public dataService: PrivilegioService,
              public global: myGlobals.Globals) { }

  formControl = new FormControl('', [
    Validators.required
    // Validators.email,
  ]);

  getErrorMessage() {
    return this.formControl.hasError('required') ? 'Required field' :
      this.formControl.hasError('email') ? 'Not a valid email' :
        '';
  }

  submit() {
    // emppty stuff
  }

  onNoClick(): void {
    this.dialogRef.close('1');
  }

  stopEdit(): void {
    this.dataService.updatePrivilegio(this.data).subscribe(res => {
      this.dialogRef.close(res);
    }, (err: HttpErrorResponse) => {
      this.global.errorCodes(err.status);
    });
  }
}
