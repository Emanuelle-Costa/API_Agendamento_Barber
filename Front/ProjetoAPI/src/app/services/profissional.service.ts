import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProfissionalService {
  baseURL = 'https://localhost:7101/api/Profissionais';

  constructor(private http: HttpClient) { }

  pegarProfissionais(){
    return this.http.get(this.baseURL)
  }

}
