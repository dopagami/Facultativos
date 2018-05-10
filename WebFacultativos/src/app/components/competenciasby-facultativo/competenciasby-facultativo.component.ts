import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { PrivilegioService } from '../../services/privilegio.service';

@Component({
  selector: 'app-competenciasby-facultativo',
  templateUrl: './competenciasby-facultativo.component.html',
  styleUrls: ['./competenciasby-facultativo.component.css']
})
export class CompetenciasbyFacultativoComponent implements OnInit {

  step: any = 0;
  formControl = new FormControl('', [Validators.required]);
  public listPrivilegios = [];

  constructor(private privilegiosService: PrivilegioService) {

    this.privilegiosService.getPrivilegios().subscribe(data => {
      this.listPrivilegios = data;
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
