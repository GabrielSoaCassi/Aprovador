import { ReclamanteService } from './reclamante.service';
import { Component, OnInit } from '@angular/core';
import { Reclamante } from '../interface/Reclamante';
import { Router } from '@angular/router';

@Component({
  selector: 'app-reclamante',
  templateUrl: './reclamante.component.html',
})
export class ReclamanteComponent implements OnInit {
  reclamantes: Reclamante[];
  id: number;
  constructor(private reclamanteService: ReclamanteService,
      private route : Router) {}

  ngOnInit(): void {
    this.reclamanteService
      .listarReclamantes()
      .subscribe((reclamante) => (this.reclamantes = reclamante));
  }

  passarIdReclamante(idDoReclamante:number) {
    this.route.navigate(['reclamantes/editar',idDoReclamante])
  }
}
