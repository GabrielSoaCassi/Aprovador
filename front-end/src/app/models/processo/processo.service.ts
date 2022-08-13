import { Processo } from './../interface/Processo';
import { HttpClient, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProcessoDTO } from '../interface/DTO/ProcessoDTO';
const rota = 'https://localhost:5001';
@Injectable({
  providedIn: 'root',
})

export class ProcessoService {
  constructor(private http: HttpClient) { }

  listarProcessos = (): Observable<Processo[]> =>
    this.http.get<Processo[]>(`${rota}/processo`);

  pesquisarProcessoPorId = (id: number): Observable<Processo> =>
    this.http.get<Processo>(`${rota}/processo/${id}`);

  cadastrarProcesso = (processo: ProcessoDTO): Observable<ProcessoDTO> =>
    this.http.post<ProcessoDTO>(`${rota}/processo`, processo);

  atualizarProcesso = (processo:ProcessoDTO):Observable<ProcessoDTO> =>
    this.http.put<ProcessoDTO>(`${rota}/processo`,processo)

  deletarProcesso = (id: number): Observable<Processo>  =>
    this.http.delete<Processo>(`${rota}/processo/${id}`)
}
