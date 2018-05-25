import { TestBed, inject } from '@angular/core/testing';

import { CuestionarioService } from './cuestionario.service';

describe('CuestionarioService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CuestionarioService]
    });
  });

  it('should be created', inject([CuestionarioService], (service: CuestionarioService) => {
    expect(service).toBeTruthy();
  }));
});
