import { ReclamanteService } from './../reclamante.service';
import { Reclamante } from './../../interface/Reclamante';
import { Component, OnChanges, OnInit, SimpleChange, SimpleChanges } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-editar-reclamante',
  templateUrl: './editar-reclamante.component.html',
})
export class EditarReclamanteComponent implements OnInit,OnChanges {
  reclamante:Reclamante;
  reclamanteNovo: Reclamante;
  reclamanteId: number;
  nome: string;
  constructor(private reclamanteService: ReclamanteService,
              private activeRoute:ActivatedRoute) { }

  ngOnInit(): void {
    this.buscarReclamanteParaEditar()
  }

  ngOnChanges(change:SimpleChanges):void{
    if(change.reclamante)
      this.buscarReclamanteParaEditar()
  }

  buscarReclamanteParaEditar() {
    let reclamanteId:number
    this.activeRoute.params.subscribe(params => reclamanteId = params.id )
    this.reclamanteService
     .listarReclamantePorId(reclamanteId)
     .subscribe(reclamante => this.reclamante = reclamante);
  }

  editarReclamante(): void {
    if (this.reclamante.id == null
      || this.reclamante.id == undefined
      || this.nome == ''
      || this.nome == null
      || this.nome == undefined)
        throw new Error()

    this.reclamanteNovo = {
      id: this.reclamante.id,
      nome: this.nome
    }
    this.reclamanteService.atualizarReclamante(this.reclamanteNovo).subscribe(() => alert('Nome do reclamante atualizado!!'))
    this.nome = '';
  }
}
