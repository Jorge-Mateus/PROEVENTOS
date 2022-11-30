import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {

  form!: FormGroup;

  constructor(public fb: FormBuilder) { }

  get f(): any{
    return this.form.controls;
  }
  ngOnInit() {
    this.validation()
  }


  public validation(){
    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.MustMatch('senha', 'confirmeSenha')
    };

    this.form = this.fb.group({
      titulo: ['', Validators.required],
      primeiroNome: ['', [Validators.required, Validators.maxLength(25), Validators.minLength(5)]],
      ultimoNome: ['', [Validators.required, Validators.maxLength(25), Validators.minLength(5)]],
      email: ['', [Validators.required,Validators.email]],
      telefone: ['', [Validators.required]],
      funcao: ['', Validators.required],
      descricao: ['',[Validators.required, Validators.maxLength(255), Validators.minLength(10)]],
      senha: ['', [Validators.required, Validators.minLength(6)]],
      confirmeSenha:['', Validators.required]
    }, formOptions)
  }

}
