import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';
import { DataTablesModule } from "angular-datatables";

import { ExportAsModule } from 'ngx-export-as';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    DataTablesModule,
    ExportAsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
