import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, RouterLink, Router } from '@angular/router';
import { FacultativoService } from '../../services/facultativo.service';
import { Facultativo } from '../../models/facultativo';
import { debug } from 'util';
import { MatExpansionModule, MatSelectModule } from '@angular/material';
import { PrivilegioService } from '../../services/privilegio.service';
import { FormControl, Validators } from '@angular/forms';
// import * as $ from 'jquery';

@Component({
  selector: 'app-facultativo',
  templateUrl: './facultativo.component.html',
  styleUrls: ['./facultativo.component.css']
})
export class FacultativoComponent implements OnInit {
  step = 0;
  public element: any = {};
  private ELEMENTS = Array<Facultativo>();
  
  formControl = new FormControl('', [Validators.required]);

  constructor( private activatedrouter: ActivatedRoute,
              private facultativoService: FacultativoService,
              private privilegiosService: PrivilegioService,
              private router: Router
  ) {

    // Nos suscribimos al router para obtener los parámetros URL.
    this.activatedrouter.params.subscribe(params => {
      // _mydata es un Observable del servicio.. nos suscribimos y filtramos.
      this.facultativoService._mydata.subscribe(resul => {
        this.element = resul[(params['id']) - 1]; // los Array empiezan en 0
      });
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
    this.router.navigate(['/competencias', this.element.id]);
  }

  ngOnInit() {

  }

}
