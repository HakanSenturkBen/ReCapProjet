import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CustomerModel } from '../models/customerModel';
import { SingleResponseModel } from '../models/singleRisponseModel';

import { Users } from '../models/userModel';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  apiUrl="https://localhost:44335/api/";

  constructor(private httpClient:HttpClient) { }
  
  getUser(user:string):Observable<SingleResponseModel<CustomerModel>>{
    return this.httpClient.get<SingleResponseModel<CustomerModel>>(this.apiUrl+"customers/GetbyEmail?email="+user);
  }
}
