import { ProcessoService } from './processo.service';
import { Component, OnInit } from '@angular/core';
import { Processo } from '../interface/Processo';
import { Route, Router } from '@angular/router';
@Component({
  selector: 'app-processo',
  templateUrl: './processo.component.html',
})
export class ProcessoComponent implements OnInit {
  processos: Processo[] = [];
  id: number;

  constructor(private processoService: ProcessoService,
              private route:Router) { }

  ngOnInit(): void
  {
    this.processoService
      .listarProcessos()
      .subscribe(processo => this.processos = processo);
  }

  passarIdProcesso(processoId:number):void{
    this.route.navigate(['processos/editar',processoId])
  }
}
