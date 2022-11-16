import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AgendaComponent } from './components/agenda/agenda.component';
import { ClientesComponent } from './components/clientes/clientes.component';
import { ContatosComponent } from './components/contatos/contatos.component';
import { DetalheProfissionalComponent } from './components/profissionais/detalhe-profissional/detalhe-profissional.component';
import { ListaProfissionalComponent } from './components/profissionais/lista-profissional/lista-profissional.component';
import { ProfissionaisComponent } from './components/profissionais/profissionais.component';
import { ServicosComponent } from './components/servicos/servicos.component';
import { CadastroComponent } from './components/usuario/cadastro/cadastro.component';
import { LoginComponent } from './components/usuario/login/login.component';
import { PerfilComponent } from './components/usuario/perfil/perfil.component';
import { UsuarioComponent } from './components/usuario/usuario.component';

const routes: Routes = [
  {
    path: 'usuario', component: UsuarioComponent,
    children:[
      { path: 'login', component: LoginComponent },
      { path: 'cadastro', component: CadastroComponent },
    ]
  },
  { path: 'usuario/perfil', component: PerfilComponent},
  { path: 'profissionais', redirectTo: 'profissionais/lista' },
  {
    path: 'profissionais', component: ProfissionaisComponent,
    children:[
      { path: 'detalhe/:id', component: DetalheProfissionalComponent },
      { path: 'detalhe', component: DetalheProfissionalComponent },
      { path: 'lista', component: ListaProfissionalComponent },
    ]
  },
  { path: 'clientes', component: ClientesComponent },
  { path: 'servicos', component: ServicosComponent },
  { path: 'agenda', component: AgendaComponent },
  { path: 'contatos', component: ContatosComponent },
  { path: '', redirectTo: 'contatos',pathMatch: 'full' },
  { path: '**', redirectTo: 'contatos',pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
