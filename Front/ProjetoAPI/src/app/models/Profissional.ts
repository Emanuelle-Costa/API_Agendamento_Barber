import { Agenda } from "./Agenda";
import { Cliente } from "./Cliente";
import { Servico } from "./Servico";

export interface Profissional {
  id: string;
  imagemURL: string;
  nome: string;
  telefone: string;
  instagram: string;
  servicos: Servico[];
  agendas: Agenda[];
  clientesProfissionais: Cliente[];
  servicosProfissionais: Servico[];
}
