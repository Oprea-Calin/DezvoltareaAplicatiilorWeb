import { Injectable } from '@angular/core';
import { ApiService } from "./api.service";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  private readonly route = 'users';

  constructor(private readonly apiService: ApiService) {
  }

  getAllData(): Observable<any> {
    return this.apiService.get(this.route+"/showData");
  }
}
