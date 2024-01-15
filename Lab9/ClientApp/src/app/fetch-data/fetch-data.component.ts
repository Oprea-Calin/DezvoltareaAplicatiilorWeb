import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ApiService } from '../core/services/api.service';
import { user } from '../data/interfaces/user';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit{
  

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private apiservice : ApiService) {

  }
  
  ngOnInit(): void {
    //this.getAllUsers();
    

  }
  //getAllUsers() {
  //  this.apiservice.getAllData().subscribe((res) => {
   //   console.log(res);
   //   this.users = res;
   // });

  }
  
