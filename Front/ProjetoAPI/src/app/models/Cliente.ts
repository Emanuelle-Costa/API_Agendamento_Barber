import { Agenda } from "./Agenda";
import { Profissional } from "./Profissional";

export interface Cliente {
  id: number;
  nome: string;
  telefone: string;
  email: string;
  senha: string;
  agendas:Agenda[];
  clientesProfissionais: Profissional[];
}
