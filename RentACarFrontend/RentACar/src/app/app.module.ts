import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {MatDialogModule} from '@angular/material/dialog';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CarComponent } from './components/car/car.component';
import { BrandComponent } from './components/brand/brand.component';
import { ColorComponent } from './components/color/color.component';
import { NaviComponent } from './components/navi/navi.component';
import { CustomerComponent } from './components/customer/customer.component';
import { CarRentalComponent } from './components/car-rental/car-rental.component';
import { FilterPipePipe } from './pipes/filter-pipe.pipe';
import { FilterPipeBrandPipe } from './pipes/filter-pipe-brand.pipe';
import { FilterPipeCarPipe } from './pipes/filter-pipe-car.pipe';
import { FilterPipeColorPipe } from './pipes/filter-pipe-color.pipe';
import { FilterPipeCarColorPipe } from './pipes/filter-pipe-car-color.pipe';

import {ToastrModule} from "ngx-toastr";
import { CarAddUpdDelComponent } from './components/car-add-upd-del/car-add-upd-del.component';
import { BrandAddUpdDelComponent } from './components/brand-add-upd-del/brand-add-upd-del.component';
import { ColorAddUpdDelComponent } from './components/color-add-upd-del/color-add-upd-del.component';
import { UpdateCarComponent } from './components/update-car/update-car.component';
import { DataManagerComponent } from './components/data-manager/data-manager.component';
import { AddUserComponent } from './components/add-user/add-user.component';
import { LoginComponent } from './components/login/login.component';
import { UsersComponent } from './components/users/users.component';
import { ValidformComponent } from './components/validform/validform.component'
import { AuthInterceptor } from './interceptors/auth.interceptor';
import {LocalStorageModule} from 'angular-2-local-storage';
import { MemberShipComponent } from './components/member-ship/member-ship.component'
import { ɵEmptyOutletComponent } from '@angular/router';



@NgModule({
  declarations: [
    AppComponent,
    CarComponent,
    BrandComponent,
    ColorComponent,
    NaviComponent,
    CustomerComponent,
    CarRentalComponent,
    FilterPipePipe,
    FilterPipeBrandPipe,
    FilterPipeCarPipe,
    FilterPipeColorPipe,
    FilterPipeCarColorPipe,
    CarAddUpdDelComponent,
    BrandAddUpdDelComponent,
    ColorAddUpdDelComponent,
    UpdateCarComponent,
    DataManagerComponent,
    AddUserComponent,
    LoginComponent,
    UsersComponent,
    ValidformComponent,
    MemberShipComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({positionClass:"toast-bottom-right"}),
    LocalStorageModule,
    MatDialogModule
  ],
  providers: [
    {provide:HTTP_INTERCEPTORS,useClass:AuthInterceptor,multi:true},
    {provide:"User",useValue:""},
  ],
  bootstrap: [AppComponent],
  entryComponents:[ɵEmptyOutletComponent]
})
export class AppModule { }
