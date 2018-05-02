import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FacultativoService } from '../../services/facultativo.service';
import { Facultativo } from '../../models/facultativo';
import { debug } from 'util';


@Component({
  selector: 'app-facultativo',
  templateUrl: './facultativo.component.html',
  styleUrls: ['./facultativo.component.css']
})
export class FacultativoComponent implements OnInit {

  public element: any = {};
  private ELEMENTS = Array<Facultativo>();

  constructor(private activatedrouter: ActivatedRoute,
    private facultativoService: FacultativoService) {

      // Nos suscribimos al router para obtener los parámetros URL.
      this.activatedrouter.params.subscribe(params => {
        // _mydata es un Observable del servicio.. nos suscribimos y filtramos.
        this.facultativoService._mydata.subscribe(resul => {
          this.element =  resul[(params['id']) - 1]; // los Array empiezan en 0
        });
      });
  }


  ngOnInit() {


  }
}
