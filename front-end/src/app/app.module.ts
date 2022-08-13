import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { TextMaskModule } from 'angular2-text-mask';

import { ProcessoComponent } from './models/processo/processo.component';
import { HeaderComponent } from './template/header/header.component';
import { FooterComponent } from './template/footer/footer.component';
import { ReclamanteComponent } from './models/reclamante/reclamante.component';
import { CadastrarReclamantesComponent } from './models/reclamante/cadastrar-reclamantes/cadastrar-reclamantes.component';
import { EscritorioComponent } from './models/escritorio/escritorio.component';
import { CadastrarEscritorioComponent } from './models/escritorio/cadastrar-escritorio/cadastrar-escritorio.component';
import { CadastrarProcessoComponent } from './models/processo/cadastrar-processo/cadastrar-processo.component';
import { EditarReclamanteComponent } from './models/reclamante/editar-reclamante/editar-reclamante.component';
import { EditarEscritorioComponent } from './models/escritorio/editar-escritorio/editar-escritorio.component';
import { EditarProcessoComponent } from './models/processo/editar-processo/editar-processo.component';

@NgModule({
  imports: [
    TextMaskModule,
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule
  ],
  declarations: [
    AppComponent,
    ProcessoComponent,
    HeaderComponent,
    FooterComponent,
    ReclamanteComponent,
    CadastrarReclamantesComponent,
    EscritorioComponent,
    CadastrarEscritorioComponent,
    CadastrarProcessoComponent,
    EditarReclamanteComponent,
    EditarEscritorioComponent,
    EditarProcessoComponent,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
