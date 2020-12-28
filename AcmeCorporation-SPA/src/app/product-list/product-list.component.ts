import { Time } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { TemplateBindingParseResult } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { baseUrl } from '../constants';
import { AlertifyService } from '../_services/alertify.service';
import { ProductService } from '../_services/product.service';
import { TimerService } from '../_services/timer.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {
  products: any;
  filteredProducts: any;
  baseUrl = baseUrl;
  constructor(private http: HttpClient, private productService: ProductService,
    private timerService: TimerService,
    private alertifyService: AlertifyService) { }

 timerObject = {
    days : 0,
    months : 0,
    hours : 0 ,
    seconds : 0
 }

  time1$ = new Date(2020, 12, 27, 6, 22);
  time2$: Observable<string>;
  ngOnInit() {
    this.getProducts();

    // let dates = new Date(2020, 12, 27, 6, 22);
    // this.time1$ = this.timerService.timer(new Date(dates.getFullYear(), dates.getMonth() - 1, dates.getDate(),
    //   dates.getHours(), dates.getMinutes()));

    // this.time2$ = this.timerService.timer(new Date(dates.getFullYear(), dates.getMonth() - 1, dates.getDate(),
    // dates.getHours(), dates.getMinutes()));
  }

  filterProduct(searchWord: string) {
    console.log(searchWord);
    if (searchWord) {
      this.filteredProducts = this.products.filter((ele, i, array) => {
          let arrayelement = ele.name.toLowerCase();
          return arrayelement.includes(searchWord);
        })
    } else {
      this.filteredProducts = this.products;
    }
    console.log(this.products);
  }

  getProducts() {
    this.productService.getProducts()
      .subscribe(products => {
        this.products = products;
        this.filteredProducts = products;
      }, error => {
          this.alertifyService.error('Something went wrong while loading the product list');
    });
  }


}
