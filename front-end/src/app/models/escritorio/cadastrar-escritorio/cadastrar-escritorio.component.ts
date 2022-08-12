import { EscritorioService } from './../escritorio.service';
import { Escritorio } from './../../interface/Escritorio';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-cadastrar-escritorio',
  templateUrl: './cadastrar-escritorio.component.html',
})
export class CadastrarEscritorioComponent {
  Escritorio!: Escritorio;
  escritorioForm: FormGroup;
  sucessoPost: boolean = false;
  erroPost: boolean = true;
  constructor(
    private escritorioService: EscritorioService,
    private fb: FormBuilder
  ) {
    this.escritorioForm = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(5)]],
    });
  }

  cadastrarEscritorio(): void {
    this.Escritorio = { nome: this.escritorioForm.controls.nome.value };
    if (this.Escritorio.nome != null || this.Escritorio.nome != undefined) {
      this.escritorioService.cadastrarEscritorios(this.Escritorio).subscribe(
        () => { this.sucessoPost = true},
        (err: HttpErrorResponse) => (this.erroPost = err.ok)
      );
      this.escritorioForm.reset();
    }
  }
  fecharAlerta(): void {
    this.erroPost = true;
    this.sucessoPost = false;
  }
}
