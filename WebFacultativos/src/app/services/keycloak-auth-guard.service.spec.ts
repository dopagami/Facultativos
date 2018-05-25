import { TestBed, inject } from '@angular/core/testing';

import { KeycloakAuthGuardService } from './keycloak-auth-guard.service';

describe('KeycloakAuthGuardService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [KeycloakAuthGuardService]
    });
  });

  it('should be created', inject([KeycloakAuthGuardService], (service: KeycloakAuthGuardService) => {
    expect(service).toBeTruthy();
  }));
});
