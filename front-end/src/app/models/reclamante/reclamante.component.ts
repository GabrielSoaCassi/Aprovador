import { ReclamanteService } from './reclamante.service';
import { Component, OnInit } from '@angular/core';
import { Reclamante } from '../interface/Reclamante';

@Component({
  selector: 'app-reclamante',
  templateUrl: './reclamante.component.html',
})
export class ReclamanteComponent implements OnInit {
  reclamantes: Reclamante[];
  id: number;
  constructor(private reclamanteService: ReclamanteService) {}

  ngOnInit(): void {
    this.reclamanteService
      .listarReclamantes()
      .subscribe((reclamante) => (this.reclamantes = reclamante));
  }

  passarIdReclamante(idDoReclamante:number) {
    console.log(idDoReclamante);
  }
}
