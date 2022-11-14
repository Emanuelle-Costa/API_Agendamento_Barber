import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'

import { ProfissionaisComponent } from './components/profissionais/profissionais.component'
import { ClienteComponent } from './components/cliente/cliente.component';
import { NavComponent } from './components/nav/nav.component';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';


import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';

import { ToastrModule } from 'ngx-toastr';


import { ProfissionalService } from './services/profissional.service';

import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';


@NgModule({
  declarations: [
    AppComponent,
    ClienteComponent,
    NavComponent,
    ProfissionaisComponent,
    DateTimeFormatPipe,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    TooltipModule.forRoot(),
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true,
    })

  ],
  providers: [ProfissionalService],
  bootstrap: [AppComponent]
})
export class AppModule { }
