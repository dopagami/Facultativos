import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { PrivilegioService } from '../../services/privilegio.service';

@Component({
  selector: 'app-competenciasby-facultativo',
  templateUrl: './competenciasby-facultativo.component.html',
  styleUrls: ['./competenciasby-facultativo.component.css']
})
export class CompetenciasbyFacultativoComponent implements OnInit {

  listCapacitacion: any;
  step: any = 0;
  formControl = new FormControl('', [Validators.required]);
  public listPrivilegios = [];

  constructor(private privilegiosService: PrivilegioService) {

    this.privilegiosService.getPrivilegios().subscribe(data => {
      this.listCapacitacion = data;
    });

    console.log('hola' + this.listCapacitacion);

    this.listPrivilegios = [
      { value: 'A', viewValue: 'Sí capacitado y autorizado' },
      { value: 'B', viewValue: 'Sí capacitado y autorizado, previa consulta, acompañado o bajo supervisión' },
      { value: 'C', viewValue: 'No capacitado o no autorizado' }
    ];

    console.log(this.listPrivilegios);
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
