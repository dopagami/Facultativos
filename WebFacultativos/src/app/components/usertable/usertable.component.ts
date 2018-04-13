import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { DataSource } from '@angular/cdk/collections';
import { User } from '../../models/user.model';
import { MatTableDataSource, MatSort, MatPaginator, MatPaginatorIntl } from '@angular/material';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'usertable',
  templateUrl: './usertable.component.html',
  styleUrls: ['./usertable.component.css']
})

export class UsertableComponent implements OnInit {
  selectedRowIndex: any;
  private ELEMENT_DATA: User[] = [];
  public tbDataSource: any;
  // public displayedColumns;

  displayedColumns = ['name', 'email', 'phone', 'website'];

  // Ordenación de columnas
  @ViewChild(MatSort) sort: MatSort;
  // Paginación
  @ViewChild(MatPaginator) paginator: MatPaginator;
  // dataSource = new UserDataSource(this.userService);


  // Función para filtrar la tabla
  applyFilter(filterValue: string) {
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // MatTableDataSource defaults to lowercase matches
    this.tbDataSource.filter = filterValue;
  }

  // Marcamos la fila seleccionada
  highlight(row) {
    console.log(row);
    this.selectedRowIndex = row.id;
  }

  constructor(private userService: UserService) {
    this.userService.getUser().subscribe(results => {
      if (!results) { return; }

      this.ELEMENT_DATA = results;
      this.tbDataSource = new MatTableDataSource<User>(this.ELEMENT_DATA);
      this.tbDataSource.sort = this.sort; // Ordenación
      this.tbDataSource.paginator = this.paginator; // Paginación

      console.log(this.ELEMENT_DATA);
    });
  }

  ngOnInit() {

  }

}

class UserDataSource extends DataSource<any> {
  constructor(private userService: UserService) {
    super();
  }
  connect(): Observable<User[]> {
    return this.userService.getUser();
  }
  disconnect() { }
}