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

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl
  }

  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }

  public verifyUser(user: Usuario): Observable<Usuario> {
    var body = {
      email: user.email,
      senha: user.senha
    }
    return this.http.post<Usuario>(this.baseUrl + "api/usuario/verifyUser", body, { headers: this.headers });
  }

  public addUser(user: Usuario) : Observable<Usuario> {
    return this.http.post<Usuario>(this.baseUrl + "api/usuario", JSON.stringify(user), { headers: this.headers });
  }

}
