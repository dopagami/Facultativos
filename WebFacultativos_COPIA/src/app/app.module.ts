import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// Este import sirve para anular las animaciones nativas
// import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';

// Keycloak
import { KeycloakService, KeycloakAngularModule } from 'keycloak-angular';
import { initializer } from './shared/app-init';
// import * as $ from 'jquery';

import {
  MatToolbarModule,
  MatTabsModule,
  MatButtonModule,
  MatIconModule,
  MatCardModule,
  MatTableModule,
  MatFormFieldModule,
  MatInputModule,
  MatSortModule,
  MatPaginatorModule,
  MatPaginatorIntl,
  MatDialogModule,
  MatSnackBarModule,
  MatSidenavModule,
  MatListModule,
  MatExpansionModule,
  MatSelectModule
} from '@angular/material';


// Routes
import { APP_ROUTING } from './app.routes';

// Componentes
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { NavbarStaticComponent } from './components/shared/navbar-static/navbar-static.component';
import { PrivilegiosComponent } from './components/privilegios/privilegios.component';
import { HomeComponent } from './components/home/home.component';
import { FacultativosComponent } from './components/facultativos/facultativos.component';
import { MatPaginatorIntlSpanish } from './components/locale/spanish-paginator-intl';
import { AddComponent } from './components/privilegios/dialogs/add/add.component';
import { EditComponent } from './components/privilegios/dialogs/edit/edit.component';
import { DeleteComponent } from './components/privilegios/dialogs/delete/delete.component';
import { LoginComponent } from './components/login/login.component';
import { UsertableComponent } from './components/usertable/usertable.component';


// Servicios
import { PrivilegioService } from './services/privilegio.service';
import { LoginService } from './services/login.service';
import { AuthGuardService } from './services/auth-guard.service';
import { FacultativoService } from './services/facultativo.service';


// Globals
import { Globals } from '../shared/globals';
import { HeaderComponent } from './components/shared/header/header.component';
import { SidenavComponent } from './components/shared/sidenav/sidenav.component';
import { FacultativoComponent } from './components/facultativo/facultativo.component';
import { CompetenciasbyFacultativoComponent } from './components/competenciasby-facultativo/competenciasby-facultativo.component';
import { CuestionarioService } from './services/cuestionario.service';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    PrivilegiosComponent,
    HomeComponent,
    FacultativosComponent,
    AddComponent,
    DeleteComponent,
    EditComponent,
    LoginComponent,
    NavbarStaticComponent,
    HeaderComponent,
    SidenavComponent,
    UsertableComponent,
    FacultativoComponent,
    CompetenciasbyFacultativoComponent

  ],
  imports: [
    BrowserModule,
    APP_ROUTING,
    MatToolbarModule,
    MatTabsModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    BrowserAnimationsModule,
    // NoopAnimationsModule,
    HttpClientModule,
    MatTableModule,
    MatFormFieldModule,
    MatInputModule,
    MatSortModule,
    MatPaginatorModule,
    BrowserModule,
    FormsModule,
    MatDialogModule,
    ReactiveFormsModule,
    MatSnackBarModule,
    MatSidenavModule,
    MatListModule,
    FlexLayoutModule,
    [KeycloakAngularModule],
    MatExpansionModule,
    MatSelectModule
  ],
  exports: [
    FormsModule,
    ReactiveFormsModule

  ],
  providers: [  FacultativoService,
                PrivilegioService,
                LoginService,
                AuthGuardService,
                MatSnackBarModule,
                UsertableComponent,
                CuestionarioService,
                Globals,
              { provide: MatPaginatorIntl, useClass: MatPaginatorIntlSpanish},
              {
                provide: APP_INITIALIZER,
                useFactory: initializer,
                multi: true,
                deps: [KeycloakService]
              }
            ],
  bootstrap: [AppComponent],
  entryComponents: [
    AddComponent,
    EditComponent,
    DeleteComponent
  ]
})
export class AppModule { }
