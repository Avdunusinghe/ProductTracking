import { Component, OnInit } from '@angular/core';
import { ProductService } from './../../Core/Services/product.service';
import { BasicProductModel } from './../../Core/models/basic.product.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  products!: Array<BasicProductModel>;

  constructor(private _productService : ProductService, private _router: Router) { }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts(){
    this._productService.getAllProducts().subscribe((data) => {
      this.products = data;
    });
  }

  update(id:number){
    this._router.navigate(['/product-detail',id]);
  }

  deleteProduct(id:number){
    this._productService.deleteProduct(id).subscribe((response) => {
      if(response.isSuccess){
        this.getProducts();
      }
    });
  }

  addNewProduct(){
    this._router.navigate(['/product-detail',0]);
  }
}
