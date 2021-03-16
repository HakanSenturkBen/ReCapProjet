import { getLocaleFirstDayOfWeek } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Car } from 'src/app/models/car';

import { CarResponseModel } from 'src/app/models/carResponseModel';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit {

  cars: Car[] = [];
  dataLoaded=false;
  currentCar:Car | undefined
  imagePath:string=""
  constructor(private carService:CarService,private activateRoute:ActivatedRoute) { }

  ngOnInit(): void {
    this.activateRoute.params.subscribe(params=>{
      if (params["brandID"]) {
        this.getCarsByBrand(params["brandID"])
      } else if (params["colorId"]){
        this.getCarsByColor(params["colorId"])
      } else {
        this.getCars()
      }
      
    })
  }

  setCurrentCar(car:Car){
    this.currentCar=car
    this.imagePath=car.carImage
  }

  getCars(){
    this.carService.getCars().subscribe(response=>{
      this.cars=response.data
      this.dataLoaded=true;
    })
  }

  getCarsByBrand(brandID:number){
      this.carService.getCarsByBrand(brandID).subscribe(
        response=>{this.cars=response.data
        this.dataLoaded=true;
      })
  }

  getCarsByColor(colorID:number){
    this.carService.getCarsByColor(colorID).subscribe(
      response=>{this.cars=response.data
      this.dataLoaded=true;
    })
  }
}
