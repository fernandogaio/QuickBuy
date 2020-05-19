import { Component, OnInit } from "@angular/core";
import { Usuario } from "../../model/usuario";
import { Router, ActivatedRoute } from "@angular/router";
import { UsuarioService } from "../../service/cadastro/usuario.service";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css",]
})

export class LoginComponent implements OnInit {
  public usuario;
  public returnUrl: string;
  public msg: string;
  private activeSpin: boolean;

  constructor(private router: Router, 
              private activatedRouter: ActivatedRoute,
              private userService: UsuarioService) {  }

  ngOnInit(): void {
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl'];
    this.usuario = new Usuario();
  }

  entrar() {
    this.activeSpin = true;
    this.userService.verifyUser(this.usuario)
      .subscribe(
        data => {
          this.userService.user = data;

          if(this.returnUrl == null)
            this.router.navigate(['/']);
          else
            this.router.navigate([this.returnUrl]);
        }, 
        err => {
          console.log(err.error);
          this.msg = err.error;
          this.activeSpin = false;
        }
      );
  }

}
