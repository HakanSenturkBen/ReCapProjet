import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/services/auth.service';


@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

  userModel:FormGroup

  
  constructor(private authService:AuthService,
    private toastrService:ToastrService,
    private formBuilder:FormBuilder) {
   }

  ngOnInit(): void {
    this.userInfo();
  }

  userInfo(){
    this.userModel=this.formBuilder.group({
    firstName:["",Validators.required],
    lastName:["",Validators.required],
    email:["",Validators.required],
    password:["",Validators.required]
  })
  }

  registerUser(){
    console.log(this.userModel)
    if (this.userModel.valid) {
      let user=Object.assign({},this.userModel.value)
      console.log(user)
      this.authService.AddUser(user).subscribe(res=>{
        
        this.toastrService.success(res.message,"Success")
      },resError=>{
        this.toastrService.warning("register mistake")
      })
    }
    this.toastrService.info("there is a missing area on form")
  }

}
