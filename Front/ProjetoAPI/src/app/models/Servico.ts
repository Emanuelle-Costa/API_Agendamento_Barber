import { Profissional } from "./Profissional";

export interface Servico {
  id: number;
  nome: string;
  valor: number;
  inicioServiço?: Date;
  fimServiço?: Date;
  profissionalId: string;
  profissional: Profissional;
  servicosProfissionais: Profissional[];
}
