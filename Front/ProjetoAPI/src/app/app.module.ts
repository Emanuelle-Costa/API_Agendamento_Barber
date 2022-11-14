import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'

import { ContatosComponent } from './components/contatos/contatos.component';
import { TituloComponent } from './shared/titulo/titulo.component';
import { ServicosComponent } from './components/servicos/servicos.component';
import { AgendaComponent } from './components/agenda/agenda.component';
import { ProfissionaisComponent } from './components/profissionais/profissionais.component'
import { ClientesComponent } from './components/clientes/clientes.component';
import { NavComponent } from './shared/nav/nav.component';
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
    ClientesComponent,
    NavComponent,
    ProfissionaisComponent,
    DateTimeFormatPipe,
    ServicosComponent,
    AgendaComponent,
    TituloComponent,
    ContatosComponent
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
