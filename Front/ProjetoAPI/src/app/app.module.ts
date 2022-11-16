import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'

import { DetalheProfissionalComponent } from './components/profissionais/detalhe-profissional/detalhe-profissional.component';
import { ListaProfissionalComponent } from './components/profissionais/lista-profissional/lista-profissional.component';
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
import { UsuarioComponent } from './components/usuario/usuario.component';
import { LoginComponent } from './components/usuario/login/login.component';
import { CadastroComponent } from './components/usuario/cadastro/cadastro.component';
import { PerfilComponent } from './components/usuario/perfil/perfil.component';



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
    ContatosComponent,
    DetalheProfissionalComponent,
    ListaProfissionalComponent,
    UsuarioComponent,
    LoginComponent,
    CadastroComponent,
    PerfilComponent
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
