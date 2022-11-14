import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AgendaComponent } from './components/agenda/agenda.component';
import { ClientesComponent } from './components/clientes/clientes.component';
import { ContatosComponent } from './components/contatos/contatos.component';
import { ProfissionaisComponent } from './components/profissionais/profissionais.component';
import { ServicosComponent } from './components/servicos/servicos.component';

const routes: Routes = [
  {path: 'profissionais', component: ProfissionaisComponent},
  {path: 'clientes', component: ClientesComponent},
  {path: 'servicos', component: ServicosComponent},
  {path: 'agenda', component: AgendaComponent},
  {path: 'contatos', component: ContatosComponent},
  {path: '', redirectTo: 'contatos',pathMatch: 'full'},
  {path: '**', redirectTo: 'contatos',pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
