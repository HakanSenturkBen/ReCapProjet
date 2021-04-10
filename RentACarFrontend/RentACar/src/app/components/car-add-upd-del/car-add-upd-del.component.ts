import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from "@angular/forms"



import { ToastrService } from 'ngx-toastr';
import { Brand } from 'src/app/models/brand';
import { Car } from 'src/app/models/car';
import { CarAdd } from 'src/app/models/carAdd';
import { Color } from 'src/app/models/color';
import { BrandService } from 'src/app/services/brand.service';
import { CarService } from 'src/app/services/car.service';
import { ColorService } from 'src/app/services/color.service';

@Component({
  selector: 'app-car-add-upd-del',
  templateUrl: './car-add-upd-del.component.html',
  styleUrls: ['./car-add-upd-del.component.css']
})
export class CarAddUpdDelComponent implements OnInit {

  carAddForm: FormGroup;
  colorAddForm: FormGroup;

  brands: Brand[] = [];
  colors: Color[] = [];
  carAdd:CarAdd;
  constructor(private formBuilder: FormBuilder,
    private toastrService: ToastrService,
    private carService: CarService,
    private brandservice: BrandService,
    private colorService: ColorService) { }

  ngOnInit(): void {
    this.creatCarAddForm()
    this.getBrand()
    this.getColor()
  }

  creatCarAddForm() {
    this.carAddForm = this.formBuilder.group({
      brandName: ["", Validators.required],
      colorName: ["", Validators.required],
      carName: ["", Validators.required],
      modelYear: ["", Validators.required],
      dailyPrice: [" ", Validators.required],
      description: [" ", Validators.required],

    })

  }

  add() {
    if (this.carAddForm.valid) {
      let carModel = Object.assign({}, this.carAddForm.value)
      let br:number=parseInt(carModel.brandName.substr(0, 1))
      let cr:number=parseInt(carModel.colorName.substr(0, 1))
      
      this.carAdd.brandID=br
      this.carAdd.colorID=cr,
      this.carAdd.carName=carModel.carName
      this.carAdd.modelYear=carModel.modelYear
      this.carAdd.dailyPrice=carModel.dailyPrice
      this.carAdd.description=carModel.description

      this.carService.add(this.carAdd).subscribe(response=>{
        console.log(response)  
        this.toastrService.info(response.message,"Congratulation")
      },responseError=>{
        console.log(responseError.error())
        this.toastrService.warning(responseError.error())}
      )
    } else {
      console.log("error")
      this.toastrService.error("wrong data input","Attetion")
    }



  }

    delete() {
    let carModel = Object.assign({}, this.carAddForm.value)

    this.toastrService.info(carModel.brandName + carModel.colorName + carModel.modelYear + carModel.dailyPrice + carModel.description)

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
