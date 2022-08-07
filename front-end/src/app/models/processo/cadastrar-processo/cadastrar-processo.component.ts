import { cnjMask, mask } from './../../../shared/masks';
import { ProcessoService } from './../processo.service';
import { Component, OnInit } from '@angular/core';
import { ReclamanteService } from '../../reclamante/reclamante.service';
import { EscritorioService } from '../../escritorio/escritorio.service';
import { Escritorio } from '../../interface/Escritorio';
import { Reclamante } from '../../interface/Reclamante';
import { Processo } from '../../interface/Processo';
@Component({
  selector: 'app-cadastrar-processo',
  templateUrl: './cadastrar-processo.component.html',
})
export class CadastrarProcessoComponent implements OnInit {
  processo: Processo;
  escritorios!: Escritorio[];
  reclamantes!: Reclamante[];
  numeroDeProcesso!: string;
  valorCausa!: number;
  reclamanteId!: number;
  escritorioId!: number;
  estadoId!: number;

  cnjMask: mask =
  {
    mask:cnjMask,
    guide:false,
    keepCharPosition:false
  }

  constructor(
    private processoService: ProcessoService,
    private reclamanteService: ReclamanteService,
    private escritorioService: EscritorioService,
  ) { }

  ngOnInit(): void {
    this.reclamanteService
      .listarReclamantes()
      .subscribe(reclamante => this.reclamantes = reclamante);

    this.escritorioService
      .listarEscritorios()
      .subscribe(escritorio => this.escritorios = escritorio);
  }

  cadastrarProcesso(): void {
    if (this.numeroDeProcesso.length != 20 || this.valorCausa < 300  || this.reclamanteId <= 0
        || this.reclamanteId == undefined || this.escritorioId <= 0 || this.escritorioId == undefined)
    {
      alert('Dados inseridos inválidos, processo não cadastrado')
      throw new Error();
    }
    this.processo = {
      numeroDeProcesso: this.numeroDeProcesso,
      valorCausa: this.valorCausa,
      reclamanteId: this.reclamanteId,
      escritorioId: this.escritorioId,
      estadoId: this.estadoId,
      ativo: true
    };
    this.processoService.cadastrarProcesso(this.processo).subscribe(() => {this.processo,alert('Processo cadastrado com sucesso!!')});
    this.numeroDeProcesso = '';
    this.valorCausa = 0;
  }
}
