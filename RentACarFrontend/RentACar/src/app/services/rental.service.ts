import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../models/listResponseModel';
import { Rental } from '../models/rental';
import { RentalResponseModel } from '../models/rentalResponseModel';

@Injectable({
  providedIn: 'root'
})
export class RentalService {

  apiUrl="https://localhost:44335/api/";

  constructor(private httpClient:HttpClient) { }

  getRentalByCarId(carId:number):Observable<ListResponseModel<Rental>>{
    let newPath=this.apiUrl+"Rentals/GetDetailCar?CarID="+carId
    return this.httpClient.get<ListResponseModel<Rental>>(newPath);
  }
  
  getRentals():Observable<RentalResponseModel>{
    let newPath=this.apiUrl+"Rentals/GetDetail"
      return this.httpClient.get<RentalResponseModel>(this.apiUrl);
    }

  
  }

  
  
