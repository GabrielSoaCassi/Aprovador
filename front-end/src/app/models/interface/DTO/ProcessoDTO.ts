import { EProcessoEstado } from "../EProcessoEstado.enum";

export interface ProcessoDTO {
  id?: number;
  numeroDeProcesso: string;
  valorCausa: number;
  reclamanteId: number;
  escritorioId: number;
  estadoId?:number;
  ativo?:boolean;
}
