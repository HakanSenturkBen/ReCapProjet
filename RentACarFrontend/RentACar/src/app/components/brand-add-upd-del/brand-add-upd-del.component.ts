import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from "@angular/forms"
import { ToastrService } from 'ngx-toastr';
import { BrandService } from 'src/app/services/brand.service';


@Component({
  selector: 'app-brand-add-upd-del',
  templateUrl: './brand-add-upd-del.component.html',
  styleUrls: ['./brand-add-upd-del.component.css']
})
export class BrandAddUpdDelComponent implements OnInit {

  brandAddForm: FormGroup;
  

  constructor(private formBuilder: FormBuilder,
    private toastrService: ToastrService,
    private brandService: BrandService) { }

  ngOnInit(): void {
    this.creatBrandAddForm();
  }

  creatBrandAddForm() {
    this.brandAddForm = this.formBuilder.group({
      brandName: ["", Validators.required],
    });
  }


  add(){
    if (this.brandAddForm.valid) {
      let brandModel = Object.assign({}, this.brandAddForm.value)
      
      this.brandService.add(brandModel).subscribe(response=>{
        this.toastrService.info(brandModel.brandName+"was added","Congratulation")
      },responseError=>{
        console.log(responseError.error())
        this.toastrService.warning(responseError.error())}
      )
    } else {
      console.log("error")
      this.toastrService.error("wrong data input","Attetion")
    }
 
  }

  
}
