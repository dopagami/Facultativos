import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Router
} from '@angular/router';
import { LoginService } from './login.service';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/take';
import 'rxjs/add/operator/map';

@Injectable()
export class AuthGuardService {

  constructor(
    private authService: LoginService,
    private router: Router
  ) {}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> {
    return this.authService.isLoggedIn       // Obtenemos del servico si está logueado o no (es un Observable)
      // tslint:disable-next-line:max-line-length
      .take(1)                               // Nos interesa el valor del Observable una única vez. Usamos take(1) (si el usuario está logueado o no)
      // tslint:disable-next-line:max-line-length
      .map((isLoggedIn: boolean) => {        // Verificaremos el valor emitido por el  BehaviorSubject y si no está logado navegaremos a la pantalla de login y return false
        if (!isLoggedIn) {
          // tslint:disable-next-line:max-line-length
          this.router.navigate(['/login']);  // {4} el AuthGuard devolverá true en caso de que el usuario esté logueado, significando que el usuario puede acceder al path "" (el cual renderiza el HomeComponent)
          return false;
        }
        return true;
      });
  }
}
