import { Component, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthenticationService } from '../../core/services/authentication.service';
import { AccountService } from '../../core/services/account.service';


@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css'],
  imports: [ReactiveFormsModule],
  standalone: true


})
export class AdminComponent implements OnInit {

    adminForm = this.formBuilder.group({
    username: null,
    email: null,
    password: null,
    FirstName: null,
    LastName: null,
    Role: null
  })

  constructor(private readonly formBuilder: FormBuilder, private readonly accountService: AccountService) { }

  ngOnInit(): void {


  }
  message: any;


  update() {
    console.log(this.adminForm.value);
    this.message = null;
    
    this.accountService.UpdateProfile(this.adminForm.value).subscribe(
      data => {
        this.message = String(data.message);
      });
  }


}
