import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, RouterLink, Router } from '@angular/router';
import { FacultativoService } from '../../services/facultativo.service';
import { Facultativo } from '../../models/facultativo';
import { debug } from 'util';
import { MatExpansionModule, MatSelectModule } from '@angular/material';
import { PrivilegioService } from '../../services/privilegio.service';
import { FormControl, Validators } from '@angular/forms';
import { FacultativosComponent } from '../facultativos/facultativos.component';
import { UsertableComponent } from '../usertable/usertable.component';


import {DomSanitizer} from '@angular/platform-browser';
import { encode } from 'punycode';
import { escape } from 'querystring';

// import * as $ from 'jquery';

@Component({
  selector: 'app-facultativo',
  templateUrl: './facultativo.component.html',
  styleUrls: ['./facultativo.component.css']
})

export class FacultativoComponent implements OnInit {
  winform: any;
  step = 0;
  public element: any = {};
  idparam: string;
  selected = false;
  private ELEMENTS = Array<Facultativo>();
 //  public ELEMENT_DATA: Facultativo[] = [];
  public  facultativo: any;

  formControl = new FormControl('', [Validators.required]);

  constructor(  private activatedrouter: ActivatedRoute,
                private facultativoService: FacultativoService,
                private privilegiosService: PrivilegioService,
                private router: Router,
                private dom: DomSanitizer
  ) {

    // Nos suscribimos al router para obtener los parámetros URL.
    this.activatedrouter.params.subscribe(params => {
      console.log(params);
      this.idparam = params['id'];
      // this.element = this.facultativoService.getRowSelected();

      // Obtiene los datos de un facultativo
      this.facultativoService.getFacultativo(params['id'], params['dpto'] ).subscribe(results => {
        this.element = results;
      });

      // }
     // console.log(this.facultativo.nombre);
      // this.el =  this.facultativoService.getFacultativobyid(params['id']);
      // this.facultativoService.getFacultativo(params['id']).subscribe(resul => {
      //     this.element = resul;
      // });
    });
  }

  // Animación de Card
  setAnimationCard(obj): void {
    const card = document.querySelector('.material-card');
    const icon = obj.target;

    // Añadimos animación css
    icon.classList.add('fa-spin-fast');

    if (card.classList.contains('mc-active')) {

      card.classList.remove('mc-active');

      setTimeout(() => {
        icon.classList.remove('fa-spin-fast');
        icon.classList.remove('fa-arrow-left');
        icon.classList.add('fa-bars');
      }, 800);

    } else {
      card.classList.add('mc-active');

      setTimeout(() => {
        icon.classList.remove('fa-spin-fast');
        icon.classList.remove('fa-bars');
        icon.classList.add('fa-arrow-left');

      }, 800);
    }
  }

  goCompetencias(): void {
    this.router.navigate(['/competencias', this.element.IDFacultativo]);
  }

  getParameters(): void {
    // tslint:disable-next-line:max-line-length
    // this.winform = this.dom.bypassSecurityTrustUrl('CUN://' + this.element.Nombre + ' ' + this.element.Apellido1 + ' ' + this.element.Apellido2);
    this.winform = this.dom.bypassSecurityTrustUrl('CUN://' + this.element.IDDepartamento + ' || ' + this.element.CodRecurso);
  }

  ngOnInit() {

  }
}
