import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClientComponent } from './Components/client/client.component';
import { ResidentialComponent } from './Components/residential/residential.component';
import { HeaderComponent } from './Components/Common/header/header.component';
import { NavBarComponent } from './Components/Common/nav-bar/nav-bar.component';
import { FooterComponent } from './Components/Common/footer/footer.component';
import { ClientListComponent } from './Components/client-list/client-list.component';

@NgModule({
  declarations: [
    AppComponent,
    ClientComponent,
    ResidentialComponent,
    HeaderComponent,
    NavBarComponent,
    FooterComponent,
    ClientListComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
