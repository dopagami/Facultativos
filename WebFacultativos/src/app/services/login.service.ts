import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { User } from '../models/user.model';
import {MatSnackBar} from '@angular/material';



@Injectable()
export class LoginService {

  private username = 'cun';
  private password = 'cun';

  private loggedIn = new BehaviorSubject<boolean>(false); // {1}

  get isLoggedIn() {
      const isAuthorized: boolean = !!localStorage.getItem('accessToken');

     return this.loggedIn.asObservable(); // {2} Devolvemos un observable
  }

  constructor(
    private router: Router,
    public snackBar: MatSnackBar
  ) {}

  login(user: User) {
    // tslint:disable-next-line:max-line-length
    if (user.userName.toUpperCase() === this.username.toUpperCase()  && user.password.toUpperCase() === this.password.toUpperCase() ) { // Login
      this.loggedIn.next(true);
      this.router.navigate(['/']);
    } else {
      this.snackBar.open('Acceso denegado');
    }
  }

  // Logout
  logout() {
    this.loggedIn.next(false);
    this.router.navigate(['/login']);
  }
}
