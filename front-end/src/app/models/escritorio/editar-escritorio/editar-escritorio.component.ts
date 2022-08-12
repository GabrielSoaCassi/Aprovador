import { EscritorioService } from './../escritorio.service';
import { Component, OnInit } from '@angular/core';
import { Escritorio } from '../../interface/Escritorio';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-editar-escritorio',
  templateUrl: './editar-escritorio.component.html',
})
export class EditarEscritorioComponent implements OnInit {
  escritorioId: number;
  sucessoPost: boolean = false;
  erroPost: boolean = true;
  escritorioForm: FormGroup;

  constructor(
    private escritorioService: EscritorioService,
    private activatedRoute: ActivatedRoute,
    private fb: FormBuilder
  ) {
    this.escritorioForm = this.fb.group({
      nome: ['', [Validators.required, Validators.min(5)]],
    });
  }

  ngOnInit(): void {
    this.trazerEscritorioParaEditar();
  }

  private trazerEscritorioParaEditar() {
    this.activatedRoute.params.subscribe(
      (params) => (this.escritorioId = params.id)
    );
    this.escritorioService
      .listarEscritorioPorId(this.escritorioId)
      .subscribe((escritorio) =>
        this.escritorioForm.patchValue({ ...escritorio })
      );
  }

  editarEscritorio(): void {
    let escritorioNovo: Escritorio = {
      id: this.escritorioId,
      nome: this.escritorioForm.controls.nome.value,
    };
    this.escritorioService
      .atualizarEscritorio(escritorioNovo)
      .subscribe(() => this.sucessoPost = true , (err:HttpErrorResponse) => this.erroPost = err.ok);
  }

  fecharAlerta(): void {
    this.erroPost = true;
    this.sucessoPost = false;
  }
}
