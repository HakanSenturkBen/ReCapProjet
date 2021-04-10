import { Component, OnInit } from '@angular/core';
import { ActivatedRouteSnapshot, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Rental } from 'src/app/models/rental';
import { RentalService } from 'src/app/services/rental.service';


@Component({
  selector: 'app-car-rental',
  templateUrl: './car-rental.component.html',
  styleUrls: ['./car-rental.component.css']
})
export class CarRentalComponent implements OnInit {

  rentals:Rental[]=[];

  dataLoaded=false;

  constructor(private rentalService:RentalService,
     private toastrService:ToastrService,
     private router:Router) { }

  ngOnInit(): void {
    this.getRentals();
    this.checkMembership()
  }

  reDirection(where:string){
    this.toastrService.info("redirection to "+where+" service")
    route: ActivatedRouteSnapshot
    this.router.navigate([where])
  }

  getRentals(){
    this.rentalService.getRentals().subscribe(response=>{
      this.rentals=response.data
      console.log(this.rentals)
      this.dataLoaded=true});
      
  }

  getMemberInfo(){

  }

  checkMembership(){
    if(localStorage.getItem("username")===null){
      this.reDirection("/memberShip")
    }else{
      this.getMemberInfo()
    }
    
  }

}
