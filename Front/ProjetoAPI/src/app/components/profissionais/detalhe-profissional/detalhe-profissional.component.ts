import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Profissional } from 'src/app/models/Profissional';
import { ProfissionalService } from 'src/app/services/profissional.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-detalhe-profissional',
  templateUrl: './detalhe-profissional.component.html',
  styleUrls: ['./detalhe-profissional.component.scss']
})
export class DetalheProfissionalComponent implements OnInit {

  profissional = {} as Profissional;
  form =  {} as FormGroup;

  get formulario(): any {
    return this.form.controls
  }

  constructor(private fb: FormBuilder,
              private router: ActivatedRoute,
              private profissionalService: ProfissionalService,
              private toastr: ToastrService) { }

  ngOnInit(): void {
    this.validacao();
    this.carregarProfissional();
  }

  public validacao(): void{
    this.form = this.fb.group({

      nome:['', [Validators.required, Validators.minLength(3), Validators.maxLength(40)]],

      imagemURL:['', Validators.required],

      instagram:['', [Validators.required, Validators.minLength(3), Validators.maxLength(25)]],

      telefone:['', Validators.required],

      email:['', [Validators.required, Validators.email]]
    });
  }

  public carregarProfissional(): void {
    const profissionalIdParam = this.router.snapshot.paramMap.get('id');

    if (profissionalIdParam !== null){
      this.profissionalService.pegaProfissionalPeloId(profissionalIdParam).subscribe(
        (profissional: Profissional) => {
          this.profissional = {...profissional};
          this.form.patchValue(this.profissional)
        },
        (error: any) => {
          console.error(error);
        },
        () => {}
      );

    }
  }

  public salvarAlteracao(): void{
    this.profissional = {...this.form.value};
    this.profissionalService.AdicionarProfissional(this.profissional).subscribe(
      () => this.toastr.success('Profissional adicionado com sucesso!', 'Sucesso'),
      (error: any) => {
        console.error(error);
        this.toastr.error('Erro ao tentar adicionar Profissional!', 'Erro');
      },
      () => {}
    )
  }


}
