
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from './components/home/home.component';
import {PrivilegiosComponent} from './components/privilegios/privilegios.component';
import {UsertableComponent} from './components/usertable/usertable.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuardService } from './services/auth-guard.service';

const APP_ROUTES: Routes = [
  { path: 'home', component: HomeComponent, canActivate: [AuthGuardService] },
  { path: 'privilegios', component: PrivilegiosComponent, canActivate: [AuthGuardService] },
  { path: 'usuarios', component: UsertableComponent, canActivate: [AuthGuardService] },
  { path: 'login', component: LoginComponent },
  { path: '**', pathMatch: 'full', redirectTo: 'home' },

];
// Forma para poder usar Hashes
// export const APP_ROUTING = RouterModule.forRoot(APP_ROUTES, {useHash:true});
export const APP_ROUTING = RouterModule.forRoot(APP_ROUTES);
