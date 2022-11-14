import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Profissional } from 'src/app/models/Profissional';
import { ProfissionalService } from 'src/app/services/profissional.service';

@Component({
  selector: 'app-profissionais',
  templateUrl: './profissionais.component.html',
  styleUrls: ['./profissionais.component.scss']
})
export class ProfissionaisComponent implements OnInit {
  modalRef?: BsModalRef;
  public profissionais: Profissional[] = [];
  public profissionaisFiltrados: Profissional[] = [];
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
    private toastr: ToastrService) { }

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


  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('Profissional excluido com sucesso!', 'Excluido!');
  }

  decline(): void {
    this.modalRef?.hide();
  }
}
