import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Brand } from 'src/app/models/brand';
import { Car } from 'src/app/models/car';
import { Color } from 'src/app/models/color';
import { BrandService } from 'src/app/services/brand.service';
import { CarService } from 'src/app/services/car.service';
import { ColorService } from 'src/app/services/color.service';

@Component({
  selector: 'app-data-manager',
  templateUrl: './data-manager.component.html',
  styleUrls: ['./data-manager.component.css']
})
export class DataManagerComponent implements OnInit {

  cars:Car[]
  brands:Brand[]
  colors:Color[]
  currentCar:Car;
  dataLoaded=true;
  imagePath:string;

  constructor(private carService:CarService,
              private brandservice: BrandService,
              private colorService: ColorService,
              private toastrService:ToastrService) { }

  ngOnInit(): void {
    
   this.getCars()
   this.getColor()
   this.getBrand()
   
   function formvalidation() {
    'use strict'
    var forms = document.querySelectorAll('.needs-validation')
  
    // Loop over them and prevent submission
    Array.prototype.slice.call(forms)
      .forEach(function (form) {
        form.addEventListener('submit', function (event: { preventDefault: () => void; stopPropagation: () => void; }) {
          if (!form.checkValidity()) {
            event.preventDefault()
            event.stopPropagation()
          }
  
          form.classList.add('was-validated')
        }, false)
      })
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


