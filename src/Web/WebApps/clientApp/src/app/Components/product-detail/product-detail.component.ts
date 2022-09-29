import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductModel } from 'src/app/Core/models/product.model';
import { ProductService } from './../../Core/Services/product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  productId : number = 0;
  public productForm! : FormGroup;
  product !: ProductModel;
  constructor
  (
    private _formBuilder : FormBuilder, 
    private _router : Router, 
    private _activatedRoute : ActivatedRoute, 
    private _ProductService : ProductService
  ) { }

  ngOnInit(): void {

    this._activatedRoute.params.subscribe((params) => {
      this.productId= +params['id'];

      if(this.productId > 0){

        this.getProductById();

      }
      this.productForm = this.createproductForm();
    });
  }

  createproductForm(): FormGroup{
    return this._formBuilder.group({
      id:[0],
      name: [null,Validators.required],
      category: [null,Validators.required],
      price: [null,Validators.required],
      quntity: [null,Validators.required],
    });
  }

  updateProductForm(): FormGroup{
    return this._formBuilder.group({
      id:[0],
      name: [{value:this.product.name},Validators.required],
      category: [{value:this.product.category},Validators.required],
      price: [{value:this.product.price},Validators.required],
      quntity: [{value:this.product.quntity},Validators.required],
    });
  }

  saveProduct(){
    this._ProductService.saveProduct(this.productForm.getRawValue()).subscribe((response) => {
      if(response.isSuccess){
        this._router.navigate(['/']);
      }
    });


  }


  getProductById(){
    console.log(this.productId);
    
    this._ProductService.getProductById(this.productId).subscribe((data) => {
      this.product = data;
      this.productForm.get('id')?.setValue(data.id);
      this.productForm.get('name')?.setValue(data.name);
      this.productForm.get('category')?.setValue(data.category);
      this.productForm.get('price')?.setValue(data.price);
      this.productForm.get('quntity')?.setValue(data.quntity);
    });
  }



  

}
