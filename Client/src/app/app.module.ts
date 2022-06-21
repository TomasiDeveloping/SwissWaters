import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import {AppRouterModule} from "./router/app-router.module";
import {Ng2SearchPipeModule} from "ng2-search-filter";
import { NgxScrollTopModule } from 'ngx-scrolltop';
import {NgxSpinnerModule} from "ngx-spinner";
import {NgChartsModule} from "ng2-charts";
import { HomeComponent } from './home/home.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {SpinnerInterceptor} from "./interceptors/spinner.interceptor";
import { StationListComponent } from './stations/station-list/station-list.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import { DashboardComponent } from './admin/dashboard/dashboard.component';
import { StationDetailComponent } from './stations/station-detail/station-detail.component';
import {ApiKeyInterceptor} from "./interceptors/api-key.interceptor";
import { FooterComponent } from './footer/footer.component';
import { AccountComponent } from './account/account.component';
import { DocumentationComponent } from './documentation/documentation.component';
import { LoginComponent } from './auth/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    StationListComponent,
    DashboardComponent,
    StationDetailComponent,
    FooterComponent,
    AccountComponent,
    DocumentationComponent,
    LoginComponent
  ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        HttpClientModule,
        AppRouterModule,
        Ng2SearchPipeModule,
        NgxScrollTopModule,
        NgxSpinnerModule,
        NgChartsModule,
        FormsModule,
        ReactiveFormsModule,
    ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: SpinnerInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: ApiKeyInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
