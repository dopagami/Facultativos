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

export class CompetenciasbyFacultativoComponent implements OnInit, OnDestroy {

  private onDestroy$ = new Subject<any>();
  selectedValue = "B"
  selected= "option1";

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

  getValue(id: string) {
    this.selectedValue = id;
    console.log('idValorSeleccionado ' + this.selectedValue);
  }

  ngOnInit() {
    // Nos suscribimos al observable para obtener los privilegios
    this.privilegiosService.getPrivilegios()
      .takeUntil(this.onDestroy$)
      .subscribe(data => {
        this.listPrivilegios = data;
        // this.onDestroy$.next(data);
      });

    // Nos suscribimos al observable para obtener un cuestionario dado
    // this.cuestionarioService.getCuestionario(1)
    // .takeUntil(this.onDestroy$)
    //   .subscribe(data => {
    //   this.listCuestionario = data;
    //   console.log(this.listCuestionario);
    // });

    // Pasar id cuestionario e id facultativo.
    this.cuestionarioService.getDetail()
      .takeUntil(this.onDestroy$)
      .subscribe(data => {
        this.listCuestionario = data;
        console.log(this.listCuestionario);
      });

      
  }

  ngOnDestroy() {
    this.onDestroy$.next();
    this.onDestroy$.complete();
  }

}
