import {NgModule} from '@angular/core';
import {RouterModule, Routes} from "@angular/router";
import {CommonModule} from "@angular/common";
import {HomeComponent} from "./home/home.component";
import {StationDetailComponent} from "./stations/station-detail/station-detail.component";

const routes: Routes = [
  {path: 'home', component: HomeComponent},
  {path: 'details/:id', component: StationDetailComponent},
  {path: '', redirectTo: '/home', pathMatch: 'full'}
];

@NgModule({
  declarations: [],
  imports: [CommonModule,RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRouterModule {
}
