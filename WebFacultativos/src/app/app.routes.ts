
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { PrivilegiosComponent } from './components/privilegios/privilegios.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuardService } from './services/auth-guard.service';
import { FacultativosComponent } from './components/facultativos/facultativos.component';
import { UsertableComponent } from './components/usertable/usertable.component';
import { FacultativoComponent } from './components/facultativo/facultativo.component';
import { CompetenciasbyFacultativoComponent } from './components/competenciasby-facultativo/competenciasby-facultativo.component';

const APP_ROUTES: Routes = [
  // { path: 'home', component: HomeComponent, canActivate: [AuthGuardService] },
  // { path: 'privilegios', component: PrivilegiosComponent, canActivate: [AuthGuardService] },
  // { path: 'usuarios', component: UsertableComponent, canActivate: [AuthGuardService] },
  // { path: 'login', component: LoginComponent },
  // { path: '**', pathMatch: 'full', redirectTo: 'home' },
  { path: 'home', component: HomeComponent },
  { path: 'privilegios', component: PrivilegiosComponent },
  { path: 'usuarios', component: UsertableComponent },
  { path: 'usuario/:id/:dpto', component: FacultativoComponent },
  { path: 'facultativos', component: FacultativosComponent },
  { path: 'competencias/:id', component: CompetenciasbyFacultativoComponent },

  // { path: 'login', component: LoginComponent },
  { path: '**', pathMatch: 'full', redirectTo: 'home' },

];
// Forma para poder usar Hashes
 export const APP_ROUTING = RouterModule.forRoot(APP_ROUTES, );
// export const APP_ROUTING = RouterModule.forRoot(APP_ROUTES, {useHash: true});
