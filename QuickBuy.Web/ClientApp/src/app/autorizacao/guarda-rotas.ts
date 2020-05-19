import { Injectable } from "@angular/core";
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { UsuarioService } from "../service/cadastro/usuario.service";

@Injectable({
  providedIn: 'root'
})

export class GuardaRotas implements CanActivate {
  constructor(private router: Router, private userService: UsuarioService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    if (this.userService.userAuth())
      return true;
    
    this.router.navigate(['/entrar'], { queryParams: { returnUrl: state.url } });
    return false;
  }

}
