import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { filter, map } from 'rxjs/operators';
import { baseUrlApi } from '../constants';
import { AlertifyService } from './alertify.service';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  // baseUrl = 'http://localhost:5000/api/';
  constructor(private http: HttpClient, private alertify: AlertifyService) {}

  getProducts() {
    return this.http.get( baseUrlApi + 'product/GetActiveProducts');
  }

  getProductById(id: any) {
    return this.http.get( baseUrlApi + 'product/get/' + id);
  }


  getAllProducts() {
    return this.http.get(baseUrlApi + 'product/get');
  }

  addProduct(product: any) {
    return this.http.post(baseUrlApi + 'product/create', product);
  }

  updateProduct(product: any) {
    return this.http.put(baseUrlApi + 'product/update', product);
  }

  deleteProduct(productId: number) {
    return this.http.delete(baseUrlApi + 'product/delete?id=' + productId);
  }


  updateProductStatus(product: any) {
    return this.http.post(baseUrlApi + 'product/updateStatus', product);
  }
}
