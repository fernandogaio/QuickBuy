import { Injectable, Inject, OnInit } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Produto } from "../../model/produto";

@Injectable({
  providedIn: "root"
})
export class ProdutoService implements OnInit {
  private baseUrl: string;
  public produtos: Produto[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void{
    this.produtos = [];   
  }

  get headers(): HttpHeaders{
    return new HttpHeaders().set('content-type', 'application/json');
  }

  public add(produto: Produto): Observable<Produto> {
    return this.http.post<Produto>(this.baseUrl + "api/produto/add", JSON.stringify(produto), { headers: this.headers });
  }
  
  public update(produto: Produto): Observable<Produto> {
    return this.http.post<Produto>(this.baseUrl + "api/produto/update", JSON.stringify(produto), { headers: this.headers });
  }

  public delete(produto: Produto): Observable<Produto> {
    return this.http.post<Produto>(this.baseUrl + "api/produto/delete", JSON.stringify(produto), { headers: this.headers });
  }

  public getAll(): Observable<Produto[]>{
    return this.http.get<Produto[]>(this.baseUrl + "api/produto");
  }

  public getById(produtoId: number): Observable<Produto>{
    return this.http.get<Produto>(this.baseUrl + "api/produto/getById?" + produtoId);  
  }

  public uploadFile(file: File): Observable<string>{
    const formData: FormData = new FormData();
    formData.append("fileSent", file, file.name)
    return this.http.post<string>(this.baseUrl + "api/produto/uploadFile", formData);
  }

}
