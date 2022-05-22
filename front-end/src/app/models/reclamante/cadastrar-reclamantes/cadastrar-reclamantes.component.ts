import { Component } from '@angular/core';
import { Reclamante } from '../../interface/Reclamante';
import { ReclamanteService } from '../reclamante.service';

@Component({
  selector: 'app-cadastrar-reclamantes',
  templateUrl: './cadastrar-reclamantes.component.html',
})
export class CadastrarReclamantesComponent {
  Reclamante!: Reclamante;
  nome!: string;
  constructor(private reclamanteService: ReclamanteService) { }

  cadastrarReclamante(): void {
    if (this.nome == null || this.nome == undefined) {
      throw new Error()
    }
    this.Reclamante = { nome: this.nome }
    if (this.Reclamante.nome !== null || this.Reclamante.nome !== undefined)
    {
      this.reclamanteService
        .cadastrarReclamante(this.Reclamante)
        .subscribe(() => alert('Reclamante cadastrado com sucesso!'));
      this.nome = '';
    }
  }
}
