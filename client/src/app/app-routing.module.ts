import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./home/home.component";
import {SweetDetailsComponent} from "./home/sweet-details/sweet-details.component";

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: ':id', component: SweetDetailsComponent},
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
