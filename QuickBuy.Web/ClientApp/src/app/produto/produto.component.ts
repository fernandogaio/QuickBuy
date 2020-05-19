import { Component, OnInit } from "@angular/core"
import { Produto } from "../model/produto";
import { ProdutoService } from "../service/produto/produto.service";

@Component({
  selector: "app-produto",
  templateUrl: "./produto.component.html",
  styleUrls: ["./produto.component.css"]
})

export class ProdutoComponent implements OnInit {
  public produto: Produto;

  constructor(private produtoService: ProdutoService){

  }

  ngOnInit(): void{
    this.produto = new Produto();
  }

  public cadastrar() {
    this.produtoService.add(this.produto)
      .subscribe(
        data => {

        },
        err => {
          
        }
      );
  }

}