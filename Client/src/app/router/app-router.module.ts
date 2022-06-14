import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes} from "@angular/router";
import {HomeComponent} from "../home/home.component";
import {DashboardComponent} from "../admin/dashboard/dashboard.component";

const routes: Routes = [
  {path: 'home', component: HomeComponent},
  // {path: 'details/:id', component: StationDetailComponent},
  {path: 'admin', component: DashboardComponent},
  {path: '', redirectTo: '/home', pathMatch: 'full'}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRouterModule { }
