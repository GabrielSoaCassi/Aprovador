import { EProcessoEstado } from './../../interface/EProcessoEstado.enum';
import { Processo } from './../../interface/Processo';
import { Escritorio } from './../../interface/Escritorio';
import { Reclamante } from './../../interface/Reclamante';
import { ProcessoService } from './../processo.service';
import { Component, OnInit } from '@angular/core';
import { ReclamanteService } from '../../reclamante/reclamante.service';
import { EscritorioService } from '../../escritorio/escritorio.service';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MaskValidator } from 'src/app/shared/masks';
import { ProcessoDTO } from '../../interface/DTO/ProcessoDTO';
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-editar-processo',
  templateUrl: './editar-processo.component.html',
})
export class EditarProcessoComponent implements OnInit {
  reclamantes!: Reclamante[];
  escritorios!: Escritorio[];
  processoForm: FormGroup;
  processoId: number;
  postSucess: boolean = false;
  erroPost: boolean = true;

  constructor(
    private processoService: ProcessoService,
    private reclamanteService: ReclamanteService,
    private escritorioService: EscritorioService,
    private activatedRoute: ActivatedRoute,
    private fb: FormBuilder
  ) {
    this.processoForm = this.fb.group({
      numeroDeProcesso: [{ value: '', disabled: true }],
      valorCausa: ['', [Validators.required, Validators.min(30000)]],
      reclamanteId: [null, [Validators.required]],
      escritorioId: [null, [Validators.required]],
      estadoId: [null],
      ativo: [],
    });
  }

  ngOnInit(): void {
    this.reclamanteService
      .listarReclamantes()
      .subscribe((reclamante) => (this.reclamantes = reclamante));

    this.escritorioService
      .listarEscritorios()
      .subscribe((escritorio) => (this.escritorios = escritorio));
    this.buscarProcessoParaEditar();
  }

  private buscarProcessoParaEditar() {
    this.activatedRoute.params.subscribe(
      (params) => (this.processoId = params.id)
    );
    this.processoService
      .pesquisarProcessoPorId(this.processoId)
      .subscribe((processo) => this.processoForm.patchValue({ ...processo }));
  }

  editarProcesso(): void {
    let processoEditado: ProcessoDTO = {
      numeroDeProcesso: this.processoForm.controls.numeroDeProcesso.value,
      valorCausa: this.processoForm.controls.valorCausa.value,
      reclamanteId: this.processoForm.controls.reclamanteId.value,
      escritorioId: this.processoForm.controls.escritorioId.value,
      estadoId: this.processoForm.controls.estadoId.value,
      ativo: this.processoForm.controls.ativo.value,
    };
    console.log('To aqui', processoEditado);
    this.processoService.atualizarProcesso(processoEditado).subscribe(
      () => {
        this.postSucess = true;
      },
      (err: HttpErrorResponse) => (this.erroPost = err.ok)
    );
  }

  fecharAlerta(): void {
    this.erroPost = true;
    this.postSucess = false;
  }
}
