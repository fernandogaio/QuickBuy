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
  public fileSelected: File;
  public activeSpin: boolean;
  public msg: string;

  constructor(private produtoService: ProdutoService){

  }

  ngOnInit(): void{
    this.produto = new Produto();
  }

  public inputChange(files: FileList) {
    this.fileSelected = files.item(0);
    this.activeSpin = true;
    this.produtoService.uploadFile(this.fileSelected).subscribe(
      r => {
        this.produto.nomeArquivo = r; 
        this.activeSpin = false;
      }, 
      e => {
        this.activeSpin = false;
      }
    );
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