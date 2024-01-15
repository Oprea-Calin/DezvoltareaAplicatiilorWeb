import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { user } from '../data/interfaces/user';
import { environment } from '../../environments/environment.prod';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {


  private readonly apiUrl = environment.apiUrl;


  constructor(private readonly httpClient: HttpClient) { }

  ngOnInit(): void {
    

}
}
