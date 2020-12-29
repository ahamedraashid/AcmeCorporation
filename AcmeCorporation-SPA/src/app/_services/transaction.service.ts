import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { baseUrlApi } from '../constants';
import { AlertifyService } from './alertify.service';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {
  constructor(private http: HttpClient, private alertify: AlertifyService) { }

  addTransaction(transaction: any) {
    return this.http.post(baseUrlApi + 'product/AddTransactionToProduct', transaction);
  }

}
