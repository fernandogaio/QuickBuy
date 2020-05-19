import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Usuario } from "../../model/usuario";

@Injectable({
  providedIn: "root"
})
export class UsuarioService{
  private baseUrl: string;
  private _user: Usuario;

  set user(user: Usuario){
    sessionStorage.setItem("usuario-autenticado", JSON.stringify(user));
    this._user = user;
  }
  get user(): Usuario {
    let data = sessionStorage.getItem("usuario-autenticado");
    this._user = JSON.parse(data);
    return this._user;
  }

  public userAuth(): boolean {
    return this._user != null && this._user.email != "" && this._user.senha != null;
  }

  public clearSession(){
    sessionStorage.setItem("usuario-autenticado", "");
    this._user = null;
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string){ }

  public verifyUser(user: Usuario) : Observable<Usuario> {
    var headers = new HttpHeaders().set('content-type', 'applicatio/json');

    var body = {
      email: user.email,
      senha: user.senha
    }
    return this.http.post<Usuario>(this.baseUrl + "api/usuario/verifyUser", body, { headers });
  }

  public addUser(user: Usuario) : Observable<Usuario> {
    var headers = new HttpHeaders().set('content-type', 'applicatio/json');

     var body = {
       email: user.email,
       senha: user.senha,
       nome: user.nome,
       sobreNome: user.sobreNome,
     }

     return this.http.post<Usuario>(this.baseUrl + "api/usuario", body, { headers });
  }

}