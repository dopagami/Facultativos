import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Facultativo } from '../../models/facultativo';
import { MatSort, MatPaginator, MatTableDataSource } from '@angular/material';
import { FacultativoService } from '../../services/facultativo.service';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { DataSource } from '@angular/cdk/collections';

@Component({
  selector: 'app-facultativos',
  templateUrl: './facultativos.component.html',
  styleUrls: ['./facultativos.component.css']
})
export class FacultativosComponent implements OnInit {

  // displayedColumns = ['nombre', 'apellido1', 'apellido2', 'categoria', 'departamento'];
  displayedColumns = ['idUser', 'id', 'title'];
  exampleDatabase: FacultativoService | null;
  dataSource: ExampleDataSource | null;
  index: number;
  id: number;

  constructor( public httpClient: HttpClient,
               public dataService: FacultativoService) { }

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild('filter') filter: ElementRef;

  ngOnInit() {
    this.loadData();
  }

  refresh() {
    this.loadData();
  }

  // Marcamos la fila seleccionada
  highlight(row) {
    console.log(row);
    // this.selectedRowIndex = row.id;
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
    this.exampleDatabase = new FacultativoService(this.httpClient);
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

export class ExampleDataSource extends DataSource<Facultativo> {
  _filterChange = new BehaviorSubject('');

  facultativo = [];
  get filter(): string {
    return this._filterChange.value;
  }

  set filter(filter: string) {
    this._filterChange.next(filter);
  }

  filteredData: Facultativo[] = [];
  renderedData: Facultativo[] = [];

  constructor(public _exampleDatabase: FacultativoService,
    public _paginator: MatPaginator,
    public _sort: MatSort) {
    super();
    // Reset to the first page when the user changes the filter.
    this._filterChange.subscribe(() => this._paginator.pageIndex = 0);
  }

  /** Connect function called by the table to retrieve one stream containing the data to render. */
  connect(): Observable<Facultativo[]> {
    // Listen for any changes in the base data, sorting, filtering, or pagination
    const displayDataChanges = [
      this._exampleDatabase.dataChange,
      this._sort.sortChange,
      this._filterChange,
      this._paginator.page
    ];

    this._exampleDatabase.getFacultativos();

    return Observable.merge(...displayDataChanges).map(() => {

      // Filter data
      this.filteredData = this._exampleDatabase.data.slice().filter((facultativo: Facultativo) => {
        // const searchStr = (privilegio.IDPrivilegio + privilegio.Valor + privilegio.Descripcion);
        const searchStr = (facultativo.IDFacultativo + facultativo.Nombre);
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
  sortData(data: Facultativo[]): Facultativo[] {
    if (!this._sort.active || this._sort.direction === '') {
      return data;
    }

    return data.sort((a, b) => {
      let propertyA: number | string = '';
      let propertyB: number | string = '';

      switch (this._sort.active) {
        case 'id': [propertyA, propertyB] = [a.IDFacultativo, b.IDFacultativo]; break;
        case 'title': [propertyA, propertyB] = [a.Nombre, b.Nombre]; break;
        // case 'descripcion': [propertyA, propertyB] = [a.Descripcion, b.Descripcion]; break;
      }

      const valueA = isNaN(+propertyA) ? propertyA : +propertyA;
      const valueB = isNaN(+propertyB) ? propertyB : +propertyB;

      return (valueA < valueB ? -1 : 1) * (this._sort.direction === 'asc' ? 1 : -1);
    });
  }
}





