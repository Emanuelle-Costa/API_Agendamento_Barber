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

}
