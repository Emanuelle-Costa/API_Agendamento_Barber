import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

import { Profissional } from 'src/app/models/Profissional';
import { ProfissionalService } from 'src/app/services/profissional.service';

@Component({
  selector: 'app-detalhe-profissional',
  templateUrl: './detalhe-profissional.component.html',
  styleUrls: ['./detalhe-profissional.component.scss']
})
export class DetalheProfissionalComponent implements OnInit {

  profissional = {} as Profissional;
  form =  {} as FormGroup;
  estadoSalvar = 'adicionar';

  get f(): any {
    return this.form.controls;
  }

  constructor(private fb: FormBuilder,
    private router: ActivatedRoute,
    private profissionalService: ProfissionalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService) { }

    public pegarProfissional(): void {
      const profissionalIdParam = this.router.snapshot.paramMap.get('id');

      if (profissionalIdParam !== null){
        this.spinner.show();

        this.estadoSalvar = 'atualizar';

        this.profissionalService.pegarProfissionalPeloId(+profissionalIdParam).subscribe(
          (profissional: Profissional) => {
            this.profissional = {...profissional};
            this.form.patchValue(this.profissional);
          },
          (error: any) => {
            console.error(error);
            this.toastr.error('Erro ao tentar carregar Profissional.', 'Erro!');
            this.spinner.hide();
          },
          () => this.spinner.hide(),
          );
        }
    }


    ngOnInit(): void {
      this.pegarProfissional();
      this.validacao();
    }

    public resetForm(): void{
      this.form.reset();
    }

    public cssValidar(campoForm: FormControl): any {
      return {'is-invalid': campoForm.errors && campoForm.touched};
    }

    public validacao(): void{

      this.form = this.fb.group({

        nome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
        imagemURL: ['', Validators.required],
        instagram: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(25)]],
        telefone: ['', Validators.required],
        email: ['', [Validators.required, Validators.email]]

      });
    }

    public salvarAlteracao(): void{
      this.spinner.show();
      if (this.form.valid){

        if(this.estadoSalvar === 'adicionar'){
          this.profissional = {...this.form.value};
          this.profissionalService['adicionar'](this.profissional).subscribe(
            () => this.toastr.success('Profissional salvo com sucesso!', 'Sucesso'),
            (error: any) => {
              console.error(error);
              this.spinner.hide();
              this.toastr.error('Erro ao salvar Profissional!', 'Erro');
            },
            () => this.spinner.hide()
            );
          } else{
            this.profissional = {id: this.profissional.id, ...this.form.value};
            this.profissionalService['atualizar'](this.profissional).subscribe(
              () => this.toastr.success('Profissional salvo com sucesso!', 'Sucesso'),
              (error: any) => {
                console.error(error);
                this.spinner.hide();
                this.toastr.error('Erro ao salvar Profissional!', 'Erro');
              },
              () => this.spinner.hide()
              );

            }
          }
        }
}
