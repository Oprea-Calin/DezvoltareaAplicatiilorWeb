import { Component, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthenticationService } from '../../core/services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  imports: [ReactiveFormsModule],
  standalone: true
})
export class LoginComponent{
  loginForm = this.formBuilder.group({
    userName: ['', Validators.required],
    password: ['', Validators.required],
  });

  constructor(private readonly formBuilder: FormBuilder, private readonly authenticationService: AuthenticationService, private router: Router) {

  }
  message: any;

  login() {
    this.authenticationService.login(this.loginForm.value).subscribe(
      (data: any) => {
        this.authenticationService.addTokenToLocalStorage(data.token);
        this.message = "User logged in!";
        this.router.navigate(['dashboard']);
      },
      response => {

      }
    );
      

    console.log(this.loginForm.value);
    
  }

}
