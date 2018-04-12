
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from './components/home/home.component';
import {PrivilegiosComponent} from './components/privilegios/privilegios.component';
import {UsertableComponent} from './components/usertable/usertable.component';

const APP_ROUTES: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'privilegios', component: PrivilegiosComponent },
  { path: 'usuarios', component: UsertableComponent },
  { path: '**', pathMatch: 'full', redirectTo: 'home' }
];
// Forma para poder usar Hashes
// export const APP_ROUTING = RouterModule.forRoot(APP_ROUTES, {useHash:true});
export const APP_ROUTING = RouterModule.forRoot(APP_ROUTES);
