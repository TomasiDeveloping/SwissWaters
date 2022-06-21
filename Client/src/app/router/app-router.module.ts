import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes} from "@angular/router";
import {HomeComponent} from "../home/home.component";
import {DashboardComponent} from "../admin/dashboard/dashboard.component";
import {StationDetailComponent} from "../stations/station-detail/station-detail.component";
import {AccountComponent} from "../account/account.component";
import {DocumentationComponent} from "../documentation/documentation.component";
import {LoginComponent} from "../auth/login/login.component";
import {AuthGuard} from "../guards/auth.guard";

const routes: Routes = [
  {path: 'home', component: HomeComponent},
  {path: 'details/:id', component: StationDetailComponent},
  //{path: 'admin', component: DashboardComponent},
  {path: 'login', component: LoginComponent},
  {path: 'account', component: AccountComponent, canActivate: [AuthGuard]},
  {path: 'documentation', component: DocumentationComponent},
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
