import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PrivilegioService } from '../../services/privilegio.service';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { MatDialog, MatPaginator, MatSort } from '@angular/material';
import { Privilegio } from '../../models/privilegio.model';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { DataSource } from '@angular/cdk/collections';
import 'rxjs/add/observable/merge';
import 'rxjs/add/observable/fromEvent';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import { AddComponent } from './dialogs/add/add.component';
import { EditComponent } from './dialogs/edit/edit.component';
import { DeleteComponent } from './dialogs/delete/delete.component';
import { debug } from 'util';


@Component({
  selector: 'app-privilegios',
  templateUrl: './privilegios.component.html',
  styleUrls: ['./privilegios.component.css']
})

export class PrivilegiosComponent implements OnInit {
  displayedColumns = ['valor', 'descripcion', 'actions'];
  exampleDatabase: PrivilegioService | null;
  dataSource: ExampleDataSource | null;
  index: number;
  id: number;
  privilegiotemp: Privilegio;


  constructor(public httpClient: HttpClient,
    public dialog: MatDialog,
    public dataService: PrivilegioService) { }

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild('filter') filter: ElementRef;

  ngOnInit() {
    this.loadData();
  }

  refresh() {
    this.loadData();
  }


  // Función genérica para mostrar errors devueltos del Backend
  // todo pasar a genérico
  errorCodes(code: number) {
    switch (code) {
      case 409:
        alert('Conflicto. Este código ya existe');
        break;

      default:
        break;
    }

  }

  // ADD
  addNew(privilegio: Privilegio) {

    const dialogRef = this.dialog.open(AddComponent, {
      data: { privilegio: privilegio },
      height: '400px',
      width: '600px'
    }
    );

    dialogRef.afterClosed().subscribe(result => {

      // Botón cancelar
      if (result === '1') { return; }

      // Para agregar, sólo anadimos una nueva fila en el DataService
      this.exampleDatabase.dataChange.value.push(result);
      this.refreshTable();
    });
  }

  // EDIT
  startEdit(i: number, id: number, valor: string, descripcion: string) {
    this.id = id;
    // index row es usado sólo para debugar
    this.index = i;
    const dialogRef = this.dialog.open(EditComponent, {
      data: { IDPrivilegio: id, Valor: valor, Descripcion: descripcion }
    });

    dialogRef.afterClosed().subscribe(result => {

      // botón cancelar
      if (result === '1') { return; }

      this.dataService.dialogData = result;
     // Buscamos por ID el  registro dentro del DataService
     const foundIndex = this.exampleDatabase.dataChange.value.findIndex(x => x.IDPrivilegio === this.id);

     // Entonces update del registro usando el DialogData (valores de la modal)
     this.exampleDatabase.dataChange.value[foundIndex] = result;
     // Refrescamos la tabla
     this.refreshTable();
    });
  }

  // DELETE
  deleteItem(i: number, id: number, valor: string, descripcion: string) {
    this.index = i;
    this.id = id;
    const dialogRef = this.dialog.open(DeleteComponent, {
      data: { id: id, valor: valor, descripcion: descripcion },
      height: '35vh'
    });

    dialogRef.afterClosed().subscribe(result => {
      // botón cancelar
      if (result === '1') { return; }

      const foundIndex = this.exampleDatabase.dataChange.value.findIndex(x => x.IDPrivilegio === this.id);
      // Para borrar usamos "splice". Así podemos borrar un sólo objeto del DataService
      this.exampleDatabase.dataChange.value.splice(foundIndex, 1);
      this.refreshTable();
    });

  }

  // If you don't need a filter or a pagination this can be simplified, you just use code from else block
  private refreshTable() {
    // if there's a paginator active we're using it for refresh
    if (this.dataSource._paginator.hasNextPage()) {
      this.dataSource._paginator.nextPage();
      this.dataSource._paginator.previousPage();
      // in case we're on last page this if will tick
    } else if (this.dataSource._paginator.hasPreviousPage()) {
      this.dataSource._paginator.previousPage();
      this.dataSource._paginator.nextPage();
      // in all other cases including active filter we do it like this
    } else {
      this.dataSource.filter = '';
      this.dataSource.filter = this.filter.nativeElement.value;
    }
  }

  public loadData() {
    this.exampleDatabase = new PrivilegioService(this.httpClient);
    this.dataSource = new ExampleDataSource(this.exampleDatabase, this.paginator, this.sort);
    Observable.fromEvent(this.filter.nativeElement, 'keyup')
      .debounceTime(150)
      .distinctUntilChanged()
      .subscribe(() => {
        if (!this.dataSource) {
          return;
        }
        this.dataSource.filter = this.filter.nativeElement.value;
      });
  }
}


export class ExampleDataSource extends DataSource<Privilegio> {
  _filterChange = new BehaviorSubject('');

  privilegio = [];
  get filter(): string {
    return this._filterChange.value;
  }

  set filter(filter: string) {
    this._filterChange.next(filter);
  }

  filteredData: Privilegio[] = [];
  renderedData: Privilegio[] = [];

  constructor(public _exampleDatabase: PrivilegioService,
    public _paginator: MatPaginator,
    public _sort: MatSort) {
    super();
    // Reset to the first page when the user changes the filter.
    this._filterChange.subscribe(() => this._paginator.pageIndex = 0);
  }

  /** Connect function called by the table to retrieve one stream containing the data to render. */
  connect(): Observable<Privilegio[]> {
    // Listen for any changes in the base data, sorting, filtering, or pagination
    const displayDataChanges = [
      this._exampleDatabase.dataChange,
      this._sort.sortChange,
      this._filterChange,
      this._paginator.page
    ];

    this._exampleDatabase.getAllPrivilegios();

    return Observable.merge(...displayDataChanges).map(() => {

      // Filter data
      this.filteredData = this._exampleDatabase.data.slice().filter((privilegio: Privilegio) => {
        // const searchStr = (privilegio.IDPrivilegio + privilegio.Valor + privilegio.Descripcion);
        const searchStr = (privilegio.Valor + privilegio.Descripcion);
        return searchStr.indexOf(this.filter.toLowerCase()) !== -1;
      });

      // Sort filtered data
      const sortedData = this.sortData(this.filteredData.slice());

      // Grab the page's slice of the filtered sorted data.
      const startIndex = this._paginator.pageIndex * this._paginator.pageSize;
      this.renderedData = sortedData.splice(startIndex, this._paginator.pageSize);
      return this.renderedData;
    });
  }
  disconnect() {
  }



  /** Returns a sorted copy of the database data. */
  sortData(data: Privilegio[]): Privilegio[] {
    if (!this._sort.active || this._sort.direction === '') {
      return data;
    }

    return data.sort((a, b) => {
      let propertyA: number | string = '';
      let propertyB: number | string = '';

      switch (this._sort.active) {
        // case 'id': [propertyA, propertyB] = [a.IDPrivilegio, b.IDPrivilegio]; break;
        case 'valor': [propertyA, propertyB] = [a.Valor, b.Valor]; break;
        case 'descripcion': [propertyA, propertyB] = [a.Descripcion, b.Descripcion]; break;
      }

      const valueA = isNaN(+propertyA) ? propertyA : +propertyA;
      const valueB = isNaN(+propertyB) ? propertyB : +propertyB;

      return (valueA < valueB ? -1 : 1) * (this._sort.direction === 'asc' ? 1 : -1);
    });
  }
}
