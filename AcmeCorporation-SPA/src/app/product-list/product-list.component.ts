import { Component, OnInit } from '@angular/core';
import { baseUrl } from '../constants';
import { AlertifyService } from '../_services/alertify.service';
import { ProductService } from '../_services/product.service';

declare var moment: any;
@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss'],
})
export class ProductListComponent implements OnInit {
  products: any;
  filteredProducts: any;
  baseUrl = baseUrl;
  constructor(
    private productService: ProductService,
    private alertifyService: AlertifyService
  ) {}
  ngOnInit() {
    this.getProducts();
  }
  filterProduct(searchWord: string) {
    if (searchWord) {
      this.filteredProducts = this.products.filter((ele, i, array) => {
        let arrayelement = ele.name.toLowerCase();
        return arrayelement.includes(searchWord);
      });
    } else {
      this.filteredProducts = this.products;
    }
  }

  getProducts() {
    this.productService.getProducts().subscribe(
      (products) => {
        this.products = products;
        this.filteredProducts = products;
        this.products.forEach((element) => {
          element.displayStartingTime = moment(element.startingTime).format(
            'LLL'
          );
          element.displayEndingTime = moment(element.endingTime).format('LLL');
        });
      },
      (error) => {
        this.alertifyService.error(
          'Something went wrong while loading the product list'
        );
      }
    );
  }
}
