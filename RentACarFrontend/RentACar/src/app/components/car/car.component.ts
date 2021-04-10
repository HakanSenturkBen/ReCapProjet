import { getLocaleFirstDayOfWeek } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Brand } from 'src/app/models/brand';
import { Car } from 'src/app/models/car';


import { CarService } from 'src/app/services/car.service';
import { BrandService } from 'src/app/services/brand.service';
import { Color } from 'src/app/models/color';
import { ColorService } from 'src/app/services/color.service';
import { ToastrService } from 'ngx-toastr';
import { RentalService } from 'src/app/services/rental.service';
import { Rental } from 'src/app/models/rental';


@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit {

  cars: Car[] = [];
  brands:Brand[]=[];
  colors:Color[]=[];
  rental:Rental[]=[];
  dataLoaded=false;
  currentCar:Car ;
  carinfo:string; 
  filterText="";
  colorFilter="";
  imagePath:string=""
  myMap=new Map()
  tarih:Date=new Date();
  adi:string="";

  constructor(private carService:CarService,
              private activateRoute:ActivatedRoute,
              private brandservice:BrandService,
              private colorservice:ColorService,
              private rentalService:RentalService,
              private toastrService:ToastrService) { }

  ngOnInit(): void {
    this.activateRoute.params.subscribe(params=>{
      if (params["brandID"]) {
        this.getCarsByBrand(params["brandID"])
      } else if (params["colorId"]){
        this.getCarsByColor(params["colorId"])
      } else {
        this.getCars()
      }
      this.getBrand()
      this.getColor();
      
    })
  }

  bugun():string{
      
    return this.tarih.toLocaleDateString();
    
  }

  setCurrentCar(car:Car){
    this.currentCar=car
    this.imagePath=car.carImage
    this.dataLoaded=false;
  }

  getCars(){
    this.carService.getCars().subscribe(response=>{
      this.cars=response.data
      this.dataLoaded=true;
    })
  }

  pushCars():Car[]{
    this.getCars();
    return this.cars
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

  getBrand(){
    this.brandservice.getBrands().subscribe(response=>{
      this.brands=response.data});
    }
  
  getColor(){
    this.colorservice.getColors().subscribe(response=>{
      this.colors=response.data});
    }

  rentalCar(car:Car){

    this.setCurrentCar(car);
    this.toastrService.success(car.brandName,"redirected to the payment page for rent");

  }

  checkCarFreeOrNot(car:Car){
    this.rentalService.getRentalByCarId(car.carID).subscribe(response=>{
      this.rental=response.data
          if(this.rental.toString()==""){
            this.rentalCar(car)
          }
      for (let i = 0; i < this.rental.length; i++) {
        const element = this.rental[i]
        
        if(!element.checkReturn){
          this.toastrService.warning("was rented. Please choose to another one", car.brandName)
        }else{
          this.rentalCar(car)
          
        }
         
      }
    });
      
    
  }

  paying (){
    this.toastrService.success("araç kiralama başarılı")
  }

  reFresh(){
    location.reload()
  }

  
}

