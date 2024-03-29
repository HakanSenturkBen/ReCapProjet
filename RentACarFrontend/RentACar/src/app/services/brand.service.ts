import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Brand } from '../models/brand';
import { BrandResponseModel } from '../models/brandResponseModel';
import { ListResponseModel } from '../models/listResponseModel';


@Injectable({
  providedIn: 'root'
})
export class BrandService {

  apiUrl="https://localhost:44335/api/";

  constructor(private httpClient:HttpClient) { }

  getBrands():Observable<ListResponseModel<Brand>>{
    return this.httpClient.get<ListResponseModel<Brand>>(this.apiUrl+"Brands/Getall");
  }

  add(brand:Brand):Observable<ListResponseModel<Brand>>{
    let params = JSON.stringify(brand);
    let headers = new HttpHeaders().set('Content-Type','application/json');

    return this.httpClient.post<ListResponseModel<Brand>>(this.apiUrl+"Brands/add",params, {headers:headers});
  }
}
