import { EscritorioService } from './../escritorio.service';
import { Escritorio } from './../../interface/Escritorio';
import { Component } from '@angular/core';
@Component({
  selector: 'app-cadastrar-escritorio',
  templateUrl: './cadastrar-escritorio.component.html',
})
export class CadastrarEscritorioComponent {
  Escritorio!: Escritorio;
  nome!: string;

  constructor(private escritorioService: EscritorioService) { }

  cadastrarEscritorio(): void {
    if (this.nome == null || this.nome == undefined || this.nome == "")
      throw new Error()
    this.Escritorio = { nome: this.nome };
    if (this.Escritorio.nome != null || this.Escritorio.nome != undefined) {
      this.escritorioService.cadastrarEscritorios(this.Escritorio).subscribe(() => alert('Escritório cadastrado com sucesso!'));
      this.nome = "";
    }
  }
}
