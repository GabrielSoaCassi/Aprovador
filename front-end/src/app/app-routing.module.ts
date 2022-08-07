import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EscritorioComponent } from './models/escritorio/escritorio.component';
import { ReclamanteComponent } from './models/reclamante/reclamante.component';
import { CadastrarReclamantesComponent } from './models/reclamante/cadastrar-reclamantes/cadastrar-reclamantes.component';
import { CadastrarEscritorioComponent } from './models/escritorio/cadastrar-escritorio/cadastrar-escritorio.component';
import { ProcessoComponent } from './models/processo/processo.component';
import { CadastrarProcessoComponent } from './models/processo/cadastrar-processo/cadastrar-processo.component';
import { EditarReclamanteComponent } from './models/reclamante/editar-reclamante/editar-reclamante.component';
import { EditarEscritorioComponent } from './models/escritorio/editar-escritorio/editar-escritorio.component';
import { EditarProcessoComponent } from './models/processo/editar-processo/editar-processo.component';
const routes: Routes = [
  { path: '', component: ProcessoComponent },
  { path: 'reclamantes', component: ReclamanteComponent },
  { path: 'reclamantes/editar/:id', component: EditarReclamanteComponent },
  { path: 'reclamantes/cadastrar', component: CadastrarReclamantesComponent },
  { path: 'escritorios', component: EscritorioComponent },
  { path: 'escritorios/cadastrar', component: CadastrarEscritorioComponent },
  { path: 'escritorios/editar/:id', component: EditarEscritorioComponent },
  { path: 'processos', component: ProcessoComponent },
  { path: 'processos/cadastrar', component: CadastrarProcessoComponent },
  { path: 'processos/editar/:id', component: EditarProcessoComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  declarations: [],
})
export class AppRoutingModule { }
