import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { LoginService } from '../../services/login.service';
import { MatSnackBar } from '@angular/material';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form: FormGroup;                    // {1}
  private formSubmitAttempt: boolean; // {2}
  private isLogged = false;

  constructor(
    private fb: FormBuilder,         // {3}
    private authService: LoginService, // {4}
    public snackBar: MatSnackBar
  ) {}

  ngOnInit() {
    this.form = this.fb.group({     // {5}
      userName: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  isFieldInvalid(field: string) { // {6}
    return (
      (!this.form.get(field).valid && this.form.get(field).touched) ||
      (this.form.get(field).untouched && this.formSubmitAttempt)
    );
  }

  onSubmit() {
    if (this.form.valid) {
      this.isLogged = this.authService.login(this.form.value); // {7}
      if (this.isLogged) {
           this.snackBar.open('Acceso denegado', 'Cerrar', {
              duration: 4000,
              extraClasses: ['white-snackbar'],
      });

      }
    }
    this.formSubmitAttempt = true;             // {8}
  }
}


