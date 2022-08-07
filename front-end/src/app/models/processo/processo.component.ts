import { ProcessoService } from './processo.service';
import { Component, OnInit } from '@angular/core';
import { Processo } from '../interface/Processo';
@Component({
  selector: 'app-processo',
  templateUrl: './processo.component.html',
})
export class ProcessoComponent implements OnInit {
  processos: Processo[] = [];
  id: number;

  constructor(private processoService: ProcessoService) { }

  ngOnInit(): void
  {
    this.processoService
      .listarProcessos()
      .subscribe(processo => {this.processos = processo
        console.log(processo)});
  }
}
