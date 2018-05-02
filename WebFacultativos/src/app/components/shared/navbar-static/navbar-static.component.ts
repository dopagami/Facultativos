import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { LoginService } from '../../../services/login.service';
import { KeycloakService } from 'keycloak-angular';
import { MatSidenavModule, MatListModule } from '@angular/material';

@Component({
  selector: 'app-navbar-static',
  templateUrl: './navbar-static.component.html',
  styleUrls: ['./navbar-static.component.css']
})
export class NavbarStaticComponent implements OnInit {

  isLoggedIn$: Observable<boolean>;                  // Variable Observable de tipo Bool

  constructor(private authService: LoginService,
              // tslint:disable-next-line:no-shadowed-variable
              private KeycloakService: KeycloakService) { }

  ngOnInit() {
    // this.isLoggedIn$ = this.authService.isLoggedIn; // Miramos si estamos logueados
  }

  onLogout() {
    // this.authService.logout();                      // {3} Hacemos Logout
     this. KeycloakService.logout();
  }

}
