import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { KeycloakService } from 'keycloak-angular';
import { Globals } from '../../../../shared/globals';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css']
})
export class SidenavComponent implements OnInit {
  @Output() closeSidenav = new EventEmitter<void>();

  // tslint:disable-next-line:no-shadowed-variable
  constructor(private KeycloakService: KeycloakService, private globals: Globals) { }

  ngOnInit() {
  }

  onClose() {
    this.closeSidenav.emit();
  }

  onLogout() {
      this.KeycloakService.logout();
  }

}
