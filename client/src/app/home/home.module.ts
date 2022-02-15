import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { SweetItemComponent } from './sweet-item/sweet-item.component';
import {SharedModule} from "../shared/shared.module";
import { SweetDetailsComponent } from './sweet-details/sweet-details.component';
import {RouterModule} from "@angular/router";



@NgModule({
  declarations: [
    HomeComponent,
    SweetItemComponent,
    SweetDetailsComponent
  ],
  exports: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule
  ]
})
export class HomeModule { }
