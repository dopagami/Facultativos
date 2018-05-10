import { Component, OnInit, ViewChild, Input } from '@angular/core';
// import { UserService } from '../../services/user.service';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { DataSource } from '@angular/cdk/collections';
// import { User } from '../../models/user.model';
import { MatTableDataSource, MatSort, MatPaginator, MatPaginatorIntl } from '@angular/material';
import { Facultativo } from '../../models/facultativo';
import { FacultativoService } from '../../services/facultativo.service';
import { RouterLink, Router } from '@angular/router';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'usertable',
  templateUrl: './usertable.component.html',
  styleUrls: ['./usertable.component.css']
})

export class UsertableComponent implements OnInit {

  selectedRowIndex: any;
  public ELEMENT_DATA: Facultativo[] = [];
  public tbDataSource: any;
  public facultativo: any;
  // public displayedColumns;

  // Columnas a mostrar y  orden de las mismas
  displayedColumns = ['nombre', 'apellido1', 'apellido2', 'departamento', 'centro'];


  // Ordenación de columnas
  @ViewChild(MatSort) sort: MatSort;
  // Paginación
  @ViewChild(MatPaginator) paginator: MatPaginator;
  dataSource = new UserDataSource(this.userService);


  // Función para filtrar la tabla
  applyFilter(filterValue: string) {
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // MatTableDataSource defaults to lowercase matches
    this.tbDataSource.filter = filterValue;
  }

  // Marcamos la fila seleccionada
  highlight(row) {

    this.selectedRowIndex = row.IDFacultativo;

    // Navegar
     this.router.navigate(['/usuario', this.selectedRowIndex, row.IDDepartamento]);
  }

  constructor(
    // private routerlink: RouterLink,
    private router: Router,
    private userService: FacultativoService) {
    this.userService.getFacultativos().subscribe(results => {
      if (!results) { return; }

      this.ELEMENT_DATA = results;
      this.tbDataSource = new MatTableDataSource<Facultativo>(this.ELEMENT_DATA);
      this.tbDataSource.sort = this.sort; // Ordenación
      this.tbDataSource.paginator = this.paginator; // Paginación

    });
  }

  ngOnInit() {
    this.tbDataSource.filter = 'Jor';
  }

}

class UserDataSource extends DataSource<any> {
  constructor(private userService: FacultativoService) {
    super();
  }
  connect(): Observable<Facultativo[]> {
    return this.userService.getFacultativos();
  }
  disconnect() { }
}
