import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrandAddUpdDelComponent } from './components/brand-add-upd-del/brand-add-upd-del.component';
import { CarAddUpdDelComponent } from './components/car-add-upd-del/car-add-upd-del.component';
import { CarComponent } from './components/car/car.component';
import { ColorAddUpdDelComponent } from './components/color-add-upd-del/color-add-upd-del.component';
import { UpdateCarComponent } from './components/update-car/update-car.component';
import { DataManagerComponent } from './components/data-manager/data-manager.component';

const routes: Routes = [
  {path:"",pathMatch:"full",component:CarComponent},
  {path:"datamanager",component:DataManagerComponent},
  {path:"Cars",component:CarComponent},
  {path:"Cars/brand/:brandID",component:CarComponent},
  {path:"Cars/color/:colorId",component:CarComponent},
  {path:"cars/add",component:CarAddUpdDelComponent},
  {path:"colors/add",component:ColorAddUpdDelComponent},
  {path:"brands/add",component:BrandAddUpdDelComponent},
  {path:"update",component:UpdateCarComponent},
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
