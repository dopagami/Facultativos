import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { KeycloakService } from 'keycloak-angular';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  @Output() sidenavToggle = new EventEmitter<void>();

  // tslint:disable-next-line:no-shadowed-variable
  constructor(private KeycloakService: KeycloakService) { }

  ngOnInit() {
  }

  onToggleSidenav() {
    this.sidenavToggle.emit();
  }

  onLogout() {
    // this.authService.logout();
     this.KeycloakService.logout(); // {3} Hacemos Logout
  }
}
