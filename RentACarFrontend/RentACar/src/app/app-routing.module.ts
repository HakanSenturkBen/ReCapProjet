import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrandAddUpdDelComponent } from './components/brand-add-upd-del/brand-add-upd-del.component';
import { CarAddUpdDelComponent } from './components/car-add-upd-del/car-add-upd-del.component';
import { CarComponent } from './components/car/car.component';
import { ColorAddUpdDelComponent } from './components/color-add-upd-del/color-add-upd-del.component';
import { UpdateCarComponent } from './components/update-car/update-car.component';
import { DataManagerComponent } from './components/data-manager/data-manager.component';
import { LoginComponent } from './components/login/login.component';
import { LoginGuard } from './guards/login.guard';
import { AddUserComponent } from './components/add-user/add-user.component';
import { ValidformComponent } from './components/validform/validform.component';
import { CarRentalComponent } from './components/car-rental/car-rental.component';
import { MemberShipComponent } from './components/member-ship/member-ship.component';

const routes: Routes = [
  {path:"",pathMatch:"full",component:ValidformComponent},
  {path:"datamanager",component:DataManagerComponent},
  { path: "login", component: LoginComponent },
  {path:"cars",component:CarComponent},
  {path:"Cars/brand/:brandID",component:CarComponent},
  {path:"Cars/color/:colorId",component:CarComponent},
  { path: "cars/add", component: CarAddUpdDelComponent, canActivate: [LoginGuard] },
  {path:"cars/add",component:CarAddUpdDelComponent},
  {path:"colors/add",component:ColorAddUpdDelComponent},
  {path:"brands/add",component:BrandAddUpdDelComponent},
  {path:"update",component:UpdateCarComponent},
  {path:"users",component:AddUserComponent},
  {path:"rental",component:CarRentalComponent},
  {path:"memberShip",component:MemberShipComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
