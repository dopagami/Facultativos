import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material';
import {Component, Inject} from '@angular/core';
import { PrivilegioService } from '../../../../services/privilegio.service';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent {

  constructor(public dialogRef: MatDialogRef<DeleteComponent>,
              @Inject(MAT_DIALOG_DATA) public data: any,
              public dataService: PrivilegioService) { }

  onNoClick(): void {
    this.dialogRef.close('1');
  }

  confirmDelete(): void {
    // this.dataService.deleteItem(this.data.id);
    this.dialogRef.close(this.data);
  }
}