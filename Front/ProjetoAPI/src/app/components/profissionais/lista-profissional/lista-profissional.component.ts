import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Profissional } from 'src/app/models/Profissional';
import { ProfissionalService } from 'src/app/services/profissional.service';

@Component({
  selector: 'app-lista-profissional',
  templateUrl: './lista-profissional.component.html',
  styleUrls: ['./lista-profissional.component.scss']
})
export class ListaProfissionalComponent implements OnInit {
  modalRef = {} as BsModalRef;
  public profissionais: Profissional[] = [];
  public profissionaisFiltrados: Profissional[] = [];
  public profissionalId = 0;
  public larguraImg: number = 80;
  public margemImg: number = 2;
  public bordasImg: number = 50;
  public exibirImg: boolean = true;
  private _filtroLista: string = '';

  public get filtroLista(){
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.profissionaisFiltrados = this.filtroLista ? this.filtrarProfissionais(this.filtroLista) : this.profissionais;
  }

  public filtrarProfissionais(filtrarPor: string): Profissional[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.profissionais.filter(
      (profissional : any) => profissional.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  constructor(
    private profissionalService: ProfissionalService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private router: Router) { }

  public ngOnInit(): void {
    this.getProfissionais();
  }

  public alterarImg(): void{
    this.exibirImg = !this.exibirImg;
  }


  public getProfissionais(): void {
    this.profissionalService.pegarProfissionais().subscribe(
      (_profissional: Profissional[]) => {
        this.profissionais = _profissional;
        this.profissionaisFiltrados = this.profissionais;
      },
      error => console.log(error)
    );
  }


  openModal(event: any, template: TemplateRef<any>, profissionalId: number): void {
    event.stopPropagation();
    this.profissionalId = profissionalId;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef.hide();

    this.profissionalService.ExcluirProfissional(this.profissionalId).subscribe(
      (resultado: any) => {
        if(resultado.mensagem === 'Deletado!'){
          this.toastr.success('Profissional excluido com sucesso!', 'Excluido!');
          this.getProfissionais();
        }
      },
      (error: any) => {
        this.toastr.error(`Erro ao tentar deletar o evento ${this.profissionalId}`, 'Erro');
        console.error(error);
      }
    )

  }

  decline(): void {
    this.modalRef?.hide();
  }

  editarProfissional(id: number): void{
    this.router.navigate([`profissionais/detalhe/${id}`]);
  }

}
