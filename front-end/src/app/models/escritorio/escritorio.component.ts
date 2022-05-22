import { Escritorio } from './../interface/Escritorio';
import { EscritorioService } from './escritorio.service';
import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-escritorio',
  templateUrl: './escritorio.component.html'
})
export class EscritorioComponent implements OnInit {
  escritorios: Escritorio[];

  constructor(private escritorioService: EscritorioService) { }

  ngOnInit(): void {
    this.escritorioService.listarEscritorios()
      .subscribe(escritorio => this.escritorios = escritorio)
  }
}
