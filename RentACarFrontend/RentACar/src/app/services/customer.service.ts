import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CustomerModel } from '../models/customerModel';
import { CustomerResponseModel } from '../models/customerResponseModel';
import { ResponseModel } from '../models/responseModel';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  apiUrl="https://localhost:44335/api/Users/GetDetail";
  apiUrl1="https://localhost:44335/api/customers/";

  constructor(private httpClient:HttpClient) { }

  getCustomers():Observable<CustomerResponseModel>{
    return this.httpClient.get<CustomerResponseModel>(this.apiUrl);
  }

  add(customer:CustomerModel):Observable<ResponseModel>{
    return this.httpClient.post<ResponseModel>(this.apiUrl1+"add",customer);
  }

}
