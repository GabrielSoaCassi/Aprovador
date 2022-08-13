import { cnjMask, mask, MaskValidator } from './../../../shared/masks';
import { ProcessoService } from './../processo.service';
import { Component, OnInit,} from '@angular/core';
import { ReclamanteService } from '../../reclamante/reclamante.service';
import { EscritorioService } from '../../escritorio/escritorio.service';
import { Escritorio } from '../../interface/Escritorio';
import { Reclamante } from '../../interface/Reclamante';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProcessoDTO } from '../../interface/DTO/ProcessoDTO';
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-cadastrar-processo',
  templateUrl: './cadastrar-processo.component.html',
  styleUrls: ['./cadastrar-processo.scss']
})
export class CadastrarProcessoComponent implements OnInit {
  escritorios!: Escritorio[];
  reclamantes!: Reclamante[];
  processoForm:FormGroup
  postSucess:boolean = false
  erroPost:boolean = true


  cnjMask: mask =
  {
    mask:cnjMask,
    guide:false,
    keepCharPosition:false
  }

  constructor(
    private processoService: ProcessoService,
    private reclamanteService: ReclamanteService,
    private escritorioService: EscritorioService,
    private fb:FormBuilder
  ) {
    this.processoForm = this.fb.group({
      numeroProcesso:['',[Validators.required,MaskValidator(this.cnjMask.mask)]],
      valorCausa:['',[Validators.required,Validators.min(30000)]],
      reclamanteId:[null,[Validators.required]],
      escritorioId:[null,[Validators.required]],

    })
  }

  ngOnInit(): void {
    this.reclamanteService
      .listarReclamantes()
      .subscribe(reclamante => this.reclamantes = reclamante);

    this.escritorioService
      .listarEscritorios()
      .subscribe(escritorio => this.escritorios = escritorio);
  }

  cadastrarProcesso(): void {
    let processo:ProcessoDTO = {
        numeroDeProcesso: this.processoForm.controls.numeroProcesso.value,
        valorCausa: this.processoForm.controls.valorCausa.value,
        reclamanteId: this.processoForm.controls.reclamanteId.value,
        escritorioId: this.processoForm.controls.escritorioId.value
     }
     this.processoService.cadastrarProcesso(processo).subscribe(() => {
      this.postSucess = true
      this.processoForm.reset()
     } , (err:HttpErrorResponse) => this.erroPost = err.ok
     )
  }

  fecharAlerta(): void {
    this.erroPost = true;
    this.postSucess = false;
  }
}
