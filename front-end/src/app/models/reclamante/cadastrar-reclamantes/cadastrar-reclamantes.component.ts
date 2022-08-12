import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnChanges, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Reclamante } from '../../interface/Reclamante';
import { ReclamanteService } from '../reclamante.service';

@Component({
  selector: 'app-cadastrar-reclamantes',
  templateUrl: './cadastrar-reclamantes.component.html',
})
export class CadastrarReclamantesComponent implements OnChanges{
  reclamante!: Reclamante;
  reclamanteForm: FormGroup;
  sucessoPost:boolean = false
  erroPost:boolean = true

  constructor(
    private reclamanteService: ReclamanteService,
    private fb: FormBuilder)
     {
    this.reclamanteForm = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(5)]],
    });
  }
  ngOnChanges(changes: SimpleChanges): void {
      if(changes.erroPost)
        console.log('toerrado')
  }
  cadastrarReclamante(): void {
      this.reclamante = {
        nome: this.reclamanteForm.controls.nome.value
      }
      console.log(this.reclamante)
    if (this.reclamante.nome !== null || this.reclamante.nome !== undefined) {
      this.reclamanteService
        .cadastrarReclamante(this.reclamante)
        .subscribe(() => {
          this.sucessoPost = true,
          this.reclamanteForm.reset()},
        (err:HttpErrorResponse) =>{ console.log('Deu Erro', this.erroPost = err.ok)})
    }
  }

  fecharAlerta():void{
    this.erroPost = true
    this.sucessoPost = false
  }
}
