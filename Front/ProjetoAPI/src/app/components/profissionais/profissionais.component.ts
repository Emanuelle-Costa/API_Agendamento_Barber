import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-profissionais',
  templateUrl: './profissionais.component.html',
  styleUrls: ['./profissionais.component.scss']
})
export class ProfissionaisComponent implements OnInit {

  public profissionais: any = [];
  public profissionaisFiltrados: any = [];
  larguraImg: number = 80;
  margemImg: number = 2;
  bordasImg: number = 50;
  exibirImg: boolean = true;
  private _filtroLista: string = '';

  public get filtroLista(){
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.profissionaisFiltrados = this.filtroLista ? this.filtrarProfissionais(this.filtroLista) : this.profissionais;
  }

  filtrarProfissionais(filtrarPor : string) : any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.profissionais.filter(
      (profissional : any) => profissional.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getProfissionais();
  }

  alterarImg(){
    this.exibirImg = !this.exibirImg;
  }
  public getProfissionais(): void {
    this.http.get('https://localhost:7101/api/Profissionais').subscribe(
      response => {
        this.profissionais = response;
        this.profissionaisFiltrados = this.profissionais;
      },
      error => console.log(error)
    );
  }
}
