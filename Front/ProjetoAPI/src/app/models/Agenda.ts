import { Cliente } from "./Cliente";
import { Profissional } from "./Profissional";

export interface Agenda {
  id: number;
  data: Date;
  profissionalId?: number;
  profissional: Profissional;
  clinteId?: string;
  cliente: Cliente;
}
