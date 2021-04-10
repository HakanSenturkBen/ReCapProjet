import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from "@angular/forms";
import { ActivatedRouteSnapshot, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm:FormGroup;
  say=0

  constructor(private formBuilder:FormBuilder, 
    private authService:AuthService, 
    private toastrService:ToastrService,
    private router:Router) { }

  ngOnInit(): void {
    this.creatLoginForm()
  }

  creatLoginForm(){
    this.loginForm=this.formBuilder.group({
      email:["",Validators.required],
      password:["",Validators.required]

    })
  }

  login(){
    if (this.loginForm.valid) {
      console.log(this.loginForm.value);
      let loginModel=Object.assign({},this.loginForm.value)
      this.authService.login(loginModel).subscribe(response=>{
        
        localStorage.setItem("token",response.data.token)
        if (response.success) {
          this.toastrService.info(response.message,"Conguratulation")
          localStorage.setItem("username",loginModel.email)  
        }
          
        },responseError=>{
          this.toastrService.error(responseError.error)
          this.say+=1;
          
      })
    }
  }

  setLogin(){
    if (this.say>=3)     {
      route: ActivatedRouteSnapshot
      this.router.navigate([""])
    }
    return this.say
  }


}
