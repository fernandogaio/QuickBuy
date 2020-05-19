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

  constructor(private userService: UsuarioService) { }
  
  ngOnInit(): void{
    this.user = new Usuario();
  }

  public add() {
    // this.userService.addUser()
    //   .subscribe(
    //     data => {

    //     },
    //     err => {

    //     }  
    //   );
  }

}