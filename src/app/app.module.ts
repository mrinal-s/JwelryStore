import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';



import { appRoutingModule } from './app.routing';

import { AppComponent } from './app.component';
import { HomeComponent } from './home';
import { LoginComponent } from './login';

import { AlertComponent } from './_components';

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpClientModule,
        FormsModule,
        appRoutingModule
    ],
    declarations: [
        AppComponent,
        HomeComponent,
        LoginComponent,
        AlertComponent
    ],

    bootstrap: [AppComponent]
})
export class AppModule { };