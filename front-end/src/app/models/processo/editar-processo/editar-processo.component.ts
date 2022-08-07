import { EProcessoEstado } from './../../interface/EProcessoEstado.enum';
import { Processo } from './../../interface/Processo';
import { Escritorio } from './../../interface/Escritorio';
import { Reclamante } from './../../interface/Reclamante';
import { ProcessoService } from './../processo.service';
import { Component, OnInit } from '@angular/core';
import { ReclamanteService } from '../../reclamante/reclamante.service';
import { EscritorioService } from '../../escritorio/escritorio.service';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-editar-processo',
  templateUrl: './editar-processo.component.html',

})
export class EditarProcessoComponent implements OnInit {
  reclamantes!: Reclamante[];
  escritorios!: Escritorio[];
  processo: Processo;
  processoEditado: Processo;
  id: number;
  valorCausa: number;
  reclamanteId: number;
  escritorioId: number;
  estadoId: EProcessoEstado;
  ativo:boolean;

  constructor(
    private processoService: ProcessoService,
    private reclamanteService: ReclamanteService,
    private escritorioService: EscritorioService,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.reclamanteService
      .listarReclamantes()
      .subscribe(reclamante => this.reclamantes = reclamante);

    this.escritorioService
      .listarEscritorios()
      .subscribe(escritorio => this.escritorios = escritorio);
      this.buscarProcessoParaEditar();
  }

  private buscarProcessoParaEditar() {
    let processoId: number;
    this.activatedRoute.params.subscribe(params => processoId = params.id);
    this.processoService
      .pesquisarProcessoPorId(processoId)
      .subscribe(processo => this.processo = processo);
  }

  editarProcesso(): void {
    if (this.processo.id == null || this.processo.id == undefined || this.valorCausa < 30000
        || this.escritorioId <= 0 || this.reclamanteId <= 0 || this.estadoId == null)
        throw new Error()
    if (this.estadoId == 1)
      this.estadoId = EProcessoEstado.aprovado
    else
      this.estadoId = EProcessoEstado.recusado
    this.processoEditado = {
      id: this.processo.id,
      numeroDeProcesso: this.processo.numeroDeProcesso,
      valorCausa: this.valorCausa,
      escritorioId: this.escritorioId,
      reclamanteId: this.reclamanteId,
      estadoId: this.estadoId,
      ativo:this.ativo
    }
    var processo = this.processoEditado
    this.processoService.atualizarProcesso(processo).subscribe(() => { alert('Processo atualizado!')})
  }
}
