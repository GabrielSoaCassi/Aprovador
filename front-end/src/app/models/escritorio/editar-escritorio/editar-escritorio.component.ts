import { EscritorioService } from './../escritorio.service';
import { Component, OnInit } from '@angular/core';
import { Escritorio } from '../../interface/Escritorio';

@Component({
  selector: 'app-editar-escritorio',
  templateUrl: './editar-escritorio.component.html',
})
export class EditarEscritorioComponent implements OnInit {
  escritorios!: Escritorio[];
  escritorioNovo: Escritorio;
  escritorioId: number;
  nome: string;

  constructor(private escritorioService: EscritorioService) { }

  ngOnInit(): void {
    this.escritorioService
      .listarEscritorios()
      .subscribe(escritorio => this.escritorios = escritorio)
  }

  editarEscritorio(): void {
    if (this.escritorioId <= 0 || this.nome == null || this.nome == undefined)
      throw new Error();
    this.escritorioNovo ={ id: this.escritorioId,nome: this.nome }
    this.escritorioService.atualizarEscritorio(this.escritorioNovo).subscribe(() => alert("Escritório atualizado!!"))
    this.nome = "";
  }
}
