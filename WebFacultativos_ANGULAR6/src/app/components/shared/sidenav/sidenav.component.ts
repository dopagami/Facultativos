import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { KeycloakService } from 'keycloak-angular';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css']
})
export class SidenavComponent implements OnInit {
  @Output() closeSidenav = new EventEmitter<void>();

  // tslint:disable-next-line:no-shadowed-variable
  constructor(private KeycloakService: KeycloakService) { }

  ngOnInit() {
  }

  onClose() {
    this.closeSidenav.emit();
  }

  onLogout() {
      this.KeycloakService.logout();
  }

}
