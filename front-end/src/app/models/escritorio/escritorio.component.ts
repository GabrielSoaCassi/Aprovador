import { Escritorio } from './../interface/Escritorio';
import { EscritorioService } from './escritorio.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-escritorio',
  templateUrl: './escritorio.component.html'
})
export class EscritorioComponent implements OnInit {
  escritorios: Escritorio[];

  constructor(private escritorioService: EscritorioService,
    private route:Router) { }

  ngOnInit(): void {
    this.escritorioService.listarEscritorios()
      .subscribe(escritorio => this.escritorios = escritorio)
  }

  passarIdEscritorio(escritorioId:number) {
    this.route.navigate(['escritorios/editar',escritorioId])
  }
}
