import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { PrivilegioService } from '../../services/privilegio.service';
import { CuestionarioService } from '../../services/cuestionario.service';
import { FacultativoService } from '../../services/facultativo.service';
import { Cuestionario } from '../../models/cuestionario';
import { Grupo } from '../../models/grupo';

@Component({
  selector: 'app-competenciasby-facultativo',
  templateUrl: './competenciasby-facultativo.component.html',
  styleUrls: ['./competenciasby-facultativo.component.css']
})

export class CompetenciasbyFacultativoComponent implements OnInit {

  step: any = 0;
  formControl = new FormControl('', [Validators.required]);
  public listPrivilegios = [];
  public listCuestionario =   Array<Cuestionario>() ;
  public listCuestionarioGrupos = Array<Grupo>();
  public dpto: string;

  constructor(private privilegiosService: PrivilegioService,
              private cuestionarioService: CuestionarioService,
              private facultativoService: FacultativoService) {

    // Nos suscribimos al observable para obtener los privilegios
    this.privilegiosService.getPrivilegios().subscribe(data => {
      this.listPrivilegios = data;
    });


    // Nos suscribimos al observable para obtener un cuestionario dado
    this.cuestionarioService.getCuestionario(1).subscribe(data => {

      this.listCuestionario = data;

      console.log(this.listCuestionario);

      // this.listCuestionarioGrupos = data['Grupos'];
    });

    this.facultativoService.element.subscribe(res => {
      this.dpto = res.Departamento;
    });

  }

  // Funciones Accordeion Panel
  setStep(index: number): void {
    this.step = index;
  }

  nextStep(): void {
    this.step++;
  }

  prevStep(): void {
    this.step--;
  }

  ngOnInit() {

  }

}
