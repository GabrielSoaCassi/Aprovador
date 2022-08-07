import { EscritorioService } from './../escritorio.service';
import { Component, OnInit } from '@angular/core';
import { Escritorio } from '../../interface/Escritorio';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-editar-escritorio',
  templateUrl: './editar-escritorio.component.html',
})
export class EditarEscritorioComponent implements OnInit {
  escritorio: Escritorio;
  escritorioNovo: Escritorio;
  escritorioId: number;
  nome: string;

  constructor(private escritorioService: EscritorioService,
    private activatedRoute:ActivatedRoute) { }

  ngOnInit(): void {
    this.trazerEscritorioParaEditar();
  }

  private trazerEscritorioParaEditar() {
    let escritorioId: number;
    this.activatedRoute.params.subscribe(params => escritorioId = params.id);
    this.escritorioService
      .listarEscritorioPorId(escritorioId)
      .subscribe(escritorio => this.escritorio = escritorio);
  }

  editarEscritorio(): void {
    if (this.escritorio.id <= 0 || this.nome == null || this.nome == undefined)
      throw new Error();
    this.escritorioNovo ={ id: this.escritorio.id,nome: this.nome }
    this.escritorioService.atualizarEscritorio(this.escritorioNovo).subscribe(() => alert("Escritório atualizado!!"))
    this.nome = "";
  }
}
