import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from './core/services/authentication.service';
import { ApiService } from './core/services/api.service';
import { user } from './data/interfaces/user';
import { UsersService } from './core/services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  loginForm = this.formBuilder.group({
    userName: ['', Validators.required],
    password: ['', Validators.required],
  });
  users: any;

  constructor(private readonly formBuilder: FormBuilder, private readonly authenticationService: AuthenticationService, private usersService: UsersService) {

  }
  ngOnInit() :void{
    this.getAllUsers();
  }

  getAllUsers() {
    this.usersService.getAllData().subscribe((res) => {
      console.log(res);
      this.users = res;
    });

  }

  login() {

    this.authenticationService.login(this.loginForm.value).subscribe((data: any) => console.log(data));

  }
 
}
