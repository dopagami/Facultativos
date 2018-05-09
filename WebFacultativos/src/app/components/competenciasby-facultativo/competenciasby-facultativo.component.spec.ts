import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompetenciasbyFacultativoComponent } from './competenciasby-facultativo.component';

describe('CompetenciasbyFacultativoComponent', () => {
  let component: CompetenciasbyFacultativoComponent;
  let fixture: ComponentFixture<CompetenciasbyFacultativoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompetenciasbyFacultativoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompetenciasbyFacultativoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
