import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { User } from '../models/user.model';
import { LoginComponent } from '../components/login/login.component';

@Injectable()
export class LoginService {

  private username = 'cun';
  private password = 'cun';
  private isLogged = false;

  private loggedIn = new BehaviorSubject<boolean>(false); // {1} Representa un valor que cambia en el tiempo

  get isLoggedIn() {
      const isAuthorized: boolean = !!localStorage.getItem('accessToken');

     return this.loggedIn.asObservable(); // {2} Devolvemos un observable
  }

  constructor(
    private router: Router
  ) {}

  login(user: User) {
    alert();
    // tslint:disable-next-line:max-line-length
    if (user.userName.toUpperCase() === this.username.toUpperCase()  && user.password.toUpperCase() === this.password.toUpperCase() ) { // Login
      this.loggedIn.next(true);
      this.router.navigate(['/']);
      return this.isLogged;
    } else {
      this.isLogged = true;
      return this.isLogged;
    }
  }

  // Logout
  logout() {
    this.loggedIn.next(false);
    this.router.navigate(['/login']);
  }
}
