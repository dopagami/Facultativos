import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { PrivilegioService } from '../../../../services/privilegio.service';
import { FormControl, Validators } from '@angular/forms';
import { Privilegio } from '../../../../models/privilegio.model';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})

export class AddComponent {
  privilegio: Privilegio[];
  displayedColumns = ['valor', 'descripcion', 'actions'];
  constructor(public dialogRef: MatDialogRef<AddComponent>,
              @Inject(MAT_DIALOG_DATA) public data: Privilegio,
              public dataService: PrivilegioService) { }

  formControl = new FormControl('', [
    Validators.required
    // Validators.email,
  ]);

  getErrorMessage() {
    return this.formControl.hasError('required') ? 'Campos requerido' : '';
    // Para validar Emails 
    // this.formControl.hasError('email') ? 'Formato de Email inválido' :
       
  }

  submit() {
  // emppty stuff
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  public confirmAdd(): void {
    
    //console.log(this.data);        
    //this.privilegio.push(this.data);
    this.dataService.addPrivilegio(this.data);
  }
}