import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from "@angular/forms";
import { ToastrService } from 'ngx-toastr';
import { ColorService } from 'src/app/services/color.service';

@Component({
  selector: 'app-color-add-upd-del',
  templateUrl: './color-add-upd-del.component.html',
  styleUrls: ['./color-add-upd-del.component.css']
})
export class ColorAddUpdDelComponent implements OnInit {

  colorAddForm: FormGroup;
  

  constructor(private formBuilder: FormBuilder,
    private toastrService: ToastrService,
    private colorService: ColorService) { }

  
  ngOnInit(): void {
    this.creatColorAddForm();
  }

  creatColorAddForm() {
    this.colorAddForm = this.formBuilder.group({
      colorName: ["", Validators.required],
    });
  }


  add(){
    if (this.colorAddForm.valid) {
      let colorModel = Object.assign({}, this.colorAddForm.value)
      
      this.colorService.add(colorModel).subscribe(response=>{
        console.log(response)  
        this.toastrService.info(colorModel.colorName,"Congratulation")
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
 
}
