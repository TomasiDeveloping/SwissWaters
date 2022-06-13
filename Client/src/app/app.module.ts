import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import {AppRouterModule} from "./aap-router.module";
import { HomeComponent } from './home/home.component';
import { StationListComponent } from './stations/station-list/station-list.component';
import {FormsModule} from "@angular/forms";
import {Ng2SearchPipeModule} from "ng2-search-filter";
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import { StationDetailComponent } from './stations/station-detail/station-detail.component';
import { WaterDataComponent } from './waters/water-data/water-data.component';
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {NgxSpinnerModule} from "ngx-spinner";
import {NgChartsModule} from "ng2-charts";
import {NgxScrollTopModule} from "ngx-scrolltop";
import {SpinnerInterceptor} from "./interceptors/spinner.interceptor";


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    StationListComponent,
    StationDetailComponent,
    WaterDataComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRouterModule,
    NgxSpinnerModule,
    FormsModule,
    Ng2SearchPipeModule,
    NgChartsModule,
    NgxScrollTopModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: SpinnerInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
