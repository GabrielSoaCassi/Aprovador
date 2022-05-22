import { Reclamante } from './../interface/Reclamante';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const rota = 'https://localhost:5001';
@Injectable({
  providedIn: 'root',
})
export class ReclamanteService {
  constructor(private http: HttpClient) { }

  listarReclamantes = (): Observable<Reclamante[]> =>
    this.http.get<Reclamante[]>(`${rota}/reclamante`)

  cadastrarReclamante = (nomeReclamante: Reclamante): Observable<Reclamante> =>
    this.http.post<Reclamante>(`${rota}/reclamante`, nomeReclamante)

  deletarReclamante = (id: number): Observable<Reclamante> =>
    this.http.delete<Reclamante>(`${rota}/reclamante/${id}`)

  atualizarReclamante = (nomeReclamante: Reclamante): Observable<Reclamante> =>
    this.http.put<Reclamante>(`${rota}/reclamante`, nomeReclamante)
}
