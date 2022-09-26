import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BasicProductModel } from './../models/basic.product.model';
import { environment } from './../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { ProductModel } from './../models/product.model';
import { ResultModel } from './../models/common/result.model';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpClient : HttpClient) { }

  getAllProducts() : Observable<Array<BasicProductModel>>{
    
    return this.httpClient.get<Array<BasicProductModel>>(environment.apiUrl + 'Product');

  }

  saveProduct(model: ProductModel) : Observable<ResultModel>{
    
    return this.httpClient.post<ResultModel>(environment.apiUrl + 'Product',model);

  }

  deleteProduct(id:number) : Observable<ResultModel>{
    
    return this.httpClient.delete<ResultModel>(environment.apiUrl + 'Product/' + id);

  }

  getProductById(id:number) : Observable<ProductModel>{
    
    return this.httpClient.get<ProductModel>(environment.apiUrl + 'Product/getProductById/' + id);
  }
}
