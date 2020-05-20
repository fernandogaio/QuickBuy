import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../service/cadastro/usuario.service';
import { Usuario } from '../../model/usuario';

@Component({
  selector: "cadastro-usuario",
  templateUrl: "./cadastro.usuario.component.html",
  styleUrls: ["./cadastro.usuario.component.css"]
})

export class CadastroUsuarioComponent implements OnInit{
  public user: Usuario;
  public activeSpin: boolean;
  public msg: string;
  public userRegistered: boolean;

  constructor(private userService: UsuarioService) { }
  
  ngOnInit(): void{
    this.user = new Usuario();
  }

  public add() {
    this.activeSpin = true;

    this.userService.addUser(this.user)
      .subscribe(
        data => {
          this.userRegistered = true;
          this.msg = "";
          this.activeSpin = false;
        },
        err => {
          this.msg = err.error;
          this.activeSpin = false;
        }  
      );
  }

}
