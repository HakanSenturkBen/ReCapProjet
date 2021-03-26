import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Color } from '../models/color';
import { ColorResponseModel } from '../models/colorResponseModel';
import { ListResponseModel } from '../models/listResponseModel';

@Injectable({
  providedIn: 'root'
})
export class ColorService {

  apiUrl="https://localhost:44335/api/";

  constructor(private httpClient:HttpClient) { }

  getColors():Observable<ColorResponseModel>{
    return this.httpClient.get<ColorResponseModel>(this.apiUrl+"Colors/Getall");
  }

  add(color:Color):Observable<ListResponseModel<Color>>{
    let params = JSON.stringify(color);
    let headers = new HttpHeaders().set('Content-Type','application/json');

    return this.httpClient.post<ListResponseModel<Color>>(this.apiUrl+"Colors/add",params, {headers:headers});
  }
}

