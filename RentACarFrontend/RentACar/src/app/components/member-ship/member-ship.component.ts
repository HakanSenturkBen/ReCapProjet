import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CustomerService } from 'src/app/services/customer.service';
import { MatDialog, MatDialogConfig} from '@angular/material/dialog'
import { ɵEmptyOutletComponent } from '@angular/router';
import { AppComponent } from 'src/app/app.component';



@Component({
  selector: 'app-member-ship',
  templateUrl: './member-ship.component.html',
  styleUrls: ['./member-ship.component.css']
})
export class MemberShipComponent implements OnInit {

  modalGroup: FormGroup;
  memberShip: FormGroup;
  calculated: boolean = false;
  puan: number = 0
  customer:any;

  constructor(private formBuilder: FormBuilder,
    private toastrService: ToastrService,
    private customerService: CustomerService,
    private dialog:MatDialog) { }

  ngOnInit(): void {
    this.elemetsOfModal()
    this.elementsOfMember()
    this.login()

    


  }
  showCalculating() {
    this.calculated = true
    console.log(this.calculated)

  }
  carpiyaBasti() {
    this.calculated = false
  }

  elementsOfMember() {
    this.memberShip = this.formBuilder.group({
      firstName: ["", Validators.required],
      lastName: ["", Validators.required],
      email: ["", Validators.required],
      password: ["", Validators.required],
      address: ["", Validators.required],
      findeksPoint: ["", Validators.required],
      creditCart: ["", Validators.required]
    });


  }

  addMemberShip(){
    console.log(this.memberShip)
    if(this.memberShip.valid){

      let customerModel=Object.assign({},this.memberShip.value)
      customerModel.findexPoint=this.puan;
      this.customerService.add(customerModel).subscribe(response=>{
        this.toastrService.info("Congratulation")
      })
      
    }this.toastrService.info("eksikleri tamamnla")
   


  }


elemetsOfModal() {
  this.modalGroup = this.formBuilder.group({
    not1: ["", Validators.required],
    not2: ["", Validators.required],
    not3: ["", Validators.required],
    not4: ["", Validators.required],
    not5: ["", Validators.required],
    not6: ["", Validators.required],
    not7: ["", Validators.required],
    not8: ["", Validators.required],
    not9: ["", Validators.required],
  })

}
findeksPointing() {
  if (this.modalGroup.valid) {
   



    this.puan = 0
    if (this.modalGroup.value.not1 == "Evet") {
      this.puan += 650
    }
    if (this.modalGroup.value.not2 == "Evet") {
      this.puan += 600
    }
    if (this.modalGroup.value.not3 == "Evet") {
      this.puan += 200
    }
    if (this.modalGroup.value.not4 == "Evet") {
      this.puan += 200
    }
    if (this.modalGroup.value.not5 == "Evet") {
      this.puan += 36
    }
    if (this.modalGroup.value.not6 == "Evet") {
      this.puan += 36
    }
    if (this.modalGroup.value.not7 == "Evet") {
      this.puan += 36
    }
    if (this.modalGroup.value.not8 == "Evet") {
      this.puan += 36
    }
    if (this.modalGroup.value.not9 == "Evet") {
      this.puan += 36
    }

  } else this.toastrService.info("boşlukları doldur");
  this.toastrService.info("findeks: " + this.puan);
  this.calculated=false;
}

login(){

  let username:any=localStorage.getItem("username");
  this.customer=JSON.parse(username)
  this.puan=this.customer.findeksPoint
  }

  onDialog(){ 
    
    const dialogConfig=new MatDialogConfig();
    dialogConfig.disableClose=true;
    dialogConfig.autoFocus=true;
    dialogConfig.width="60%";

    // this.dialog.open(MemberShipComponent)

  }

}
