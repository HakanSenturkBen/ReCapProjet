import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Brand } from 'src/app/models/brand';
import { Car } from 'src/app/models/car';
import { Color } from 'src/app/models/color';
import { BrandService } from 'src/app/services/brand.service';
import { CarService } from 'src/app/services/car.service';
import { ColorService } from 'src/app/services/color.service';
import { FormGroup, FormBuilder, FormControl, Validators, FormArray } from "@angular/forms"
import { CarAdd } from 'src/app/models/carAdd';
import { CarInfoDetail } from 'src/app/models/carInfoDetail';

@Component({
  selector: 'app-data-manager',
  templateUrl: './data-manager.component.html',
  styleUrls: ['./data-manager.component.css']
})
export class DataManagerComponent implements OnInit {

  cars:Car[];
  brands:Brand[];
  colors:Color[];
  currentCar:Car;
  dataLoaded=true;
  imagePath:string;
  carUpdate:FormGroup;
  
  car:CarAdd;
  carInfoDetail:CarInfoDetail;

  mistakes: string[]

  constructor(private carService:CarService,
              private brandservice: BrandService,
              private colorService: ColorService,
              private toastrService:ToastrService,
              private formBuilder:FormBuilder) { }

  ngOnInit(): void {
   this.carUpdateElements()
   this.getCars()
   this.getColor()
   this.getBrand()
   
     
  }

  OnSubmit(form:any):void{
    this.mistakes=this.findInvalidControls(this.carUpdate)
  }

  findInvalidControls(f: FormGroup) {
    const invalid = [];
    const controls = f.controls;
    for (const name in controls) {
      if (controls[name].invalid) {
        invalid.push(name);
      }
    }
    return invalid;
  }

  carUpdateElements(){
     this.carUpdate=this.formBuilder.group({
      brandName:["",Validators.required],
      colorName:["",Validators.required],
      carName:["",Validators.required],
      modelYear:["",Validators.required],
      dailyPrice:["",Validators.required],
      description:["",Validators.required],
      manifacturer:["",Validators.required],
      production:["",Validators.required],
      assembly:["",Validators.required],
      designer:["",Validators.required],
      class:["",Validators.required],
      bodyStyle:["",Validators.required],
      engine:["",Validators.required],
      powerOut:["",Validators.required],
      transmission:["",Validators.required],
     })
  }

  update(){
    if (this.carUpdate.valid) {
      
      let carModel=Object.assign({},this.carUpdate.value);
      console.log(carModel)

      this.carInfoDetail={Id:this.currentCar.carID,
                          carID:this.currentCar.carID,
                          brandID:parseInt(carModel.brandName.split("-",1)),
                          colorID:parseInt(carModel.colorName.split("-",1)),
                          manifacturer:carModel.manifacturer,
                          production:carModel.production,
                          assembly:carModel.assembly,
                          designer:carModel.designer,
                          class:carModel.class,
                          bodyStyle:carModel.bodyStyle,
                          engine:carModel.engine,
                          powerOut:carModel.powerOut,
                          transmission:carModel.transmission};
      
      this.carService.updateInfoCar(this.carInfoDetail).subscribe(
      response=>{this.toastrService.info("id: "+this.carInfoDetail.Id+"carID: "+this.carInfoDetail.carID+" "+this.carInfoDetail.brandID,"Congratulation")
          });
    
      this.car={carID:this.currentCar.carID,
            brandID:parseInt(carModel.brandName.split("-",1)),
            colorID:parseInt(carModel.colorName.split("-",1)),
            carName:this.currentCar.carName,
            modelYear:this.currentCar.modelYear,
            dailyPrice:this.currentCar.dailyPrice,
            description:this.currentCar.description};
          

      this.carService.updateCar(this.car).subscribe(
              response=>{
                if (response.success) {
                  this.toastrService.info("Congratulation")
                  console.log(response.message)  
                }else{
                  console.log(console.error())
                  this.toastrService.info("hassiktir")
                }
               
                });
         
    }else{
      
      this.toastrService.warning("Eksik alanları doldurunuz ")  
      
    }
    
  }
  
  getCars(){
    this.carService.getCars().subscribe(response=>{
      this.cars=response.data
    })
  }
  
  setCurrentCar(car:Car){
    this.currentCar=car
    this.imagePath=car.carImage
    this.dataLoaded=false
    this.toastrService.info("redirecting to data update page","Hold it:)")


  }

  getBrand() {
    this.brandservice.getBrands().subscribe(response => {
      this.brands = response.data
    });
  }

  getColor() {
    this.colorService.getColors().subscribe(response => {
      this.colors = response.data
    });
  }

 
}


