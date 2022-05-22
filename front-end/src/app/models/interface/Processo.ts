import { EProcessoEstado } from './EProcessoEstado.enum';
import { Escritorio } from './Escritorio';
import { Reclamante } from './Reclamante';
export interface Processo {
  id?: number;
  numeroDeProcesso: string;
  valorCausa: number;
  reclamanteId: number;
  escritorioId: number;
  reclamante?: Reclamante;
  escritorio?: Escritorio;
  estadoId?:EProcessoEstado;
  estado?:string;
  ativo:boolean;
}
