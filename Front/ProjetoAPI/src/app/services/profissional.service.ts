import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Profissional } from '../models/Profissional';

@Injectable()
export class ProfissionalService {
  baseURL = 'https://localhost:7101/api/Profissionais';

  constructor(private http: HttpClient) { }

  public pegarProfissionais(): Observable<Profissional[]>{
    return this.http.get<Profissional[]>(this.baseURL)
  }

  public pegaProfissionalPeloId(id: number): Observable<Profissional>{
    return this.http.get<Profissional>(`${this.baseURL}/${id}`);
  }

  public AdicionarProfissional(profissional: Profissional): Observable<Profissional>{
    return this.http.post<Profissional>(this.baseURL, profissional);
  }

  public AtualizarProfissional(id: number, profissional: Profissional): Observable<Profissional>{
    return this.http.put<Profissional>(`${this.baseURL}/${id}`, profissional);
  }

  public ExcluirProfissional(id: number): Observable<any>{
    return this.http.delete(`${this.baseURL}/${id}`);
  }

}
