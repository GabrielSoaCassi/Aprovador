import { ReclamanteService } from './../reclamante.service';
import { Reclamante } from './../../interface/Reclamante';
import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-editar-reclamante',
  templateUrl: './editar-reclamante.component.html',
})
export class EditarReclamanteComponent implements OnInit {
  reclamantes!: Reclamante[];
  reclamanteNovo: Reclamante;
  reclamanteId: number;
  nome: string;
  constructor(private reclamanteService: ReclamanteService) { }

  ngOnInit(): void {
    this.reclamanteService
      .listarReclamantes()
      .subscribe(reclamante => this.reclamantes = reclamante);
  }

  editarReclamante(): void {
    if (this.reclamanteId == null
      || this.reclamanteId == undefined
      || this.nome == ''
      || this.nome == null
      || this.nome == undefined)
        throw new Error()

    this.reclamanteNovo = {
      id: this.reclamanteId,
      nome: this.nome
    }
    this.reclamanteService.atualizarReclamante(this.reclamanteNovo).subscribe(() => alert('Nome do reclamante atualizado!!'))
    this.nome = '';
  }
}
