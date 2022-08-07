import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Escritorio } from '../interface/Escritorio';

const rota = 'https://localhost:5001';

@Injectable({
  providedIn: 'root',
})
export class EscritorioService {
  constructor(private http: HttpClient) { }

  listarEscritorios = (): Observable<Escritorio[]> =>
    this.http.get<Escritorio[]>(`${rota}/escritorio`);

  listarEscritorioPorId = (id:number): Observable<Escritorio> =>
    this.http.get<Escritorio>(`${rota}/escritorio/${id}`);

  cadastrarEscritorios = (nome: Escritorio): Observable<Escritorio> =>
    this.http.post<Escritorio>(`${rota}/escritorio`, nome);

  deletarEscritorio = (id: number): Observable<Escritorio> =>
    this.http.delete<Escritorio>(`${rota}/escritorio/${id}`)

  atualizarEscritorio =
  (escritorioNovo: Escritorio): Observable<Escritorio> =>
    this.http.put<Escritorio>(`${rota}/escritorio`, escritorioNovo);
}
