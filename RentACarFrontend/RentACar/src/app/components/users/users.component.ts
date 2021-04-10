import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators,FormControl } from '@angular/forms';
import { ActivatedRouteSnapshot, Router } from '@angular/router';

import { ToastrService } from 'ngx-toastr';
import { CustomerModel } from 'src/app/models/customerModel';
import { Users } from 'src/app/models/userModel';
import { StorageLocalService } from 'src/app/services/storage-local.service';
import { UsersService } from 'src/app/services/users.service';


@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  userModel:FormGroup;
  currentUser:CustomerModel;
  username:any;
  login:boolean=false;
  entriesCount:number=0
  

  constructor(private formBuilder:FormBuilder,
    private userServis:UsersService,
    private toastrService:ToastrService,
    private router:Router,
    private storageLokal:StorageLocalService
    ) { }

  ngOnInit(): void {

    this.usersElements()
     
    this.logIn()

    
  }

  usersElements(){
    this.userModel=this.formBuilder.group({
    email:["",Validators.required],
    password:["",Validators.required],
    })
    

  }

  reDirection(where:string){
      this.toastrService.info("redirection to "+where+" service")
      route: ActivatedRouteSnapshot
      this.router.navigate([where])
    }

  logOut(){
      localStorage.removeItem("username")
      this.login=false
      location.reload();
  }

  logIn(){
    this.username=localStorage.getItem("username")
    let userModel=JSON.parse(this.username)
    this.username=userModel.firstName+" "+userModel.lastName
    this.login=true
    this.toastrService.info("welcome dear " +userModel.firstName+" "+ userModel.lastName)
    
    
  }

  


  getUser(){
    if(this.userModel.valid){
      let userModel=Object.assign({},this.userModel.value) 

      this.userServis.getUser(userModel.email).subscribe
      (res=>{this.currentUser=res.data
        
        if (res.data==null) {
          
          this.mistake(userModel.email+"user not found")
        }else{
          this.storageLokal.loadObject("username",this.currentUser)
          this.username=userModel.firstName+" "+userModel.lastName
          location.reload();
          this.login=true;
          console.log(userModel)
          this.toastrService.info(userModel.email+" "+res.message+"login successfull")
        }
    });
    }else{
      this.mistake("Please enter a valid e-mail and password. ")
    }
    
  }

  mistake(message:string){
    this.toastrService.error(message,"Attention")
    this.entriesCount+=1
    if (this.entriesCount>3){ 
      this.login=false
      this.username=""
      if(location.pathname!="/users")this.reDirection("users")
      this.entriesCount=0
      
    }

  }


}
