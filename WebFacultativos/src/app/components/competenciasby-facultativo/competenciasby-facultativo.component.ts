import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { PrivilegioService } from '../../services/privilegio.service';
import { CuestionarioService } from '../../services/cuestionario.service';
import { FacultativoService } from '../../services/facultativo.service';
import { Cuestionario } from '../../models/cuestionario';
import { Grupo } from '../../models/grupo';
// tslint:disable-next-line:import-blacklist
import { Subscription, Subject } from 'rxjs';
import { Privilegio } from '../../models/privilegio.model';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-competenciasby-facultativo',
  templateUrl: './competenciasby-facultativo.component.html',
  styleUrls: ['./competenciasby-facultativo.component.css']
})

export class CompetenciasbyFacultativoComponent implements OnInit {

  private onDestroy$ = new Subject<any>();
  step: any = 0;
  formControl = new FormControl('', [Validators.required]);
  public listPrivilegios = Array<Privilegio>();
  public listCuestionario = Array<Cuestionario>();
  public listCuestionarioGrupos = Array<Grupo>();
  public dpto: string;

  constructor(private privilegiosService: PrivilegioService,
    private cuestionarioService: CuestionarioService,
    private facultativoService: FacultativoService) {
      // Departamento
      this.facultativoService.element.subscribe(res => {
        this.dpto = res.Departamento;
      });

  }

  // Funciones Accordeion Panel
  // setStep(index: number): void {
  //   this.step = index;
  // }

  // nextStep(): void {
  //   this.step++;
  // }

  // prevStep(): void {
  //   this.step--;
  // }


  ngOnInit() {
    // Nos suscribimos al observable para obtener los privilegios
    this.privilegiosService.getPrivilegios()
      .subscribe(data => {
        this.listPrivilegios = data;
        // this.onDestroy$.next(data);
      });

    // Pasar id cuestionario e id facultativo.
    this.cuestionarioService.getDetail()
      .subscribe(data => {
        this.listCuestionario = data;
        console.log(this.listCuestionario);
      });
  }

  // Obligatorio hacer unsuscribe para evitar Memeory Leak. http, routerlink, async pipe gestionan automáticamente el unsuscribe.
  // ngOnDestroy() {
  //   this.onDestroy$.next();
  //   this.onDestroy$.complete();
  // }

}
