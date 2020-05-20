import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UsuarioService } from '../service/cadastro/usuario.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(private router: Router, private userService: UsuarioService) { }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  public userAuth(): boolean {
    return this.userService.userAuth();
  }

  exit() {
    this.userService.clearSession();
    this.router.navigate(['/'])
  }

  get user() {
    return this.userService.user;
  }
}
