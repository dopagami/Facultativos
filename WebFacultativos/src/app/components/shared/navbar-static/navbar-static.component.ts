import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { LoginService } from '../../../services/login.service';

@Component({
  selector: 'app-navbar-static',
  templateUrl: './navbar-static.component.html',
  styleUrls: ['./navbar-static.component.css']
})
export class NavbarStaticComponent implements OnInit {

  isLoggedIn$: Observable<boolean>;                  // Variable Observable de tipo Bool

  constructor(private authService: LoginService) { }

  ngOnInit() {
    this.isLoggedIn$ = this.authService.isLoggedIn; // Miramos si estamos logueados
  }

  onLogout() {
    this.authService.logout();                      // {3} Hacemos Logout
  }

}
