import { ReclamanteService } from './../reclamante.service';
import { Reclamante } from './../../interface/Reclamante';
import {
  Component,
  OnChanges,
  OnInit,
  SimpleChange,
  SimpleChanges,
} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-editar-reclamante',
  templateUrl: './editar-reclamante.component.html',
})
export class EditarReclamanteComponent implements OnInit, OnChanges {
  reclamanteId: number;
  reclamante: Reclamante;
  reclamanteForm: FormGroup;
  sucessoPost: boolean = false;
  erroPost: boolean = true;
  constructor(
    private reclamanteService: ReclamanteService,
    private activeRoute: ActivatedRoute,
    private fb: FormBuilder
  ) {
    this.reclamanteForm = this.fb.group({
      nome: ['', [Validators.required, Validators.min(5)]],
    });
  }

  ngOnInit(): void {
    this.buscarReclamanteParaEditar();
  }

  ngOnChanges(change: SimpleChanges): void {
    if (change.reclamante) console.log('mudei');
  }

  buscarReclamanteParaEditar() {
    this.activeRoute.params.subscribe(
      (params) => (this.reclamanteId = params.id)
    );
    this.reclamanteService
      .listarReclamantePorId(this.reclamanteId)
      .subscribe((reclamante) => {
        this.reclamanteForm.patchValue({ ...reclamante });
      });
  }

  editarReclamante(): void {
    var reclamanteNovo: Reclamante = {
      id: this.reclamanteId,
      nome: this.reclamanteForm.controls.nome.value,
    };
    this.reclamanteService.atualizarReclamante(reclamanteNovo).subscribe(
      () => (this.sucessoPost = true),
      (err: HttpErrorResponse) => (this.erroPost = err.ok)
    );
  }

  fecharAlerta(): void {
    this.erroPost = true;
    this.sucessoPost = false;
  }
}
