import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

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
  MatSnackBarModule
} from '@angular/material';


// Routes
import { APP_ROUTING } from './app.routes';

// Componentes
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { NavbarStaticComponent } from './components/shared/navbar-static/navbar-static.component';
import { PrivilegiosComponent } from './components/privilegios/privilegios.component';
import { HomeComponent } from './components/home/home.component';
import { UsertableComponent } from './components/usertable/usertable.component';
import { MatPaginatorIntlSpanish } from './components/locale/spanish-paginator-intl';
import { AddComponent } from './components/privilegios/dialogs/add/add.component';
import { EditComponent } from './components/privilegios/dialogs/edit/edit.component';
import { DeleteComponent } from './components/privilegios/dialogs/delete/delete.component';
import { LoginComponent } from './components/login/login.component';



// Servicios
import { UserService } from './services/user.service';
import { PrivilegioService } from './services/privilegio.service';
import { LoginService } from './services/login.service';
import { AuthGuardService } from './services/auth-guard.service';

// Globals
import { Globals } from '../shared/globals';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    PrivilegiosComponent,
    HomeComponent,
    UsertableComponent,
    AddComponent,
    DeleteComponent,
    EditComponent,
    LoginComponent,
    NavbarStaticComponent
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
    NoopAnimationsModule,
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
    MatSnackBarModule
  ],
  exports: [
    FormsModule,
    ReactiveFormsModule
    
  ],
  providers: [  UserService,
                PrivilegioService,
                LoginService,
                AuthGuardService,
                MatSnackBarModule,
                Globals,
              { provide: MatPaginatorIntl, useClass: MatPaginatorIntlSpanish}
            ],
  bootstrap: [AppComponent],
  entryComponents: [
    AddComponent,
    EditComponent,
    DeleteComponent
  ]
})
export class AppModule { }
