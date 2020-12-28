import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ProductStatus } from '../enums';
import { ProductService } from '../_services/product.service';

@Component({
  selector: 'app-product-admin-list',
  templateUrl: './product-admin-list.component.html',
  styleUrls: ['./product-admin-list.component.scss']
})
export class ProductAdminListComponent implements OnInit {
  @Input() loggedInAsAdmin: boolean;
  productList: any;

  headElements = ['Id', 'Name', 'Starting Bid', 'Current Bid', 'St. Time', 'End Time', 'Status'];
  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.getAllProducts();
  }

  // getAllProducts() {
  //   this.productService.getAllProducts().pipe(map((p: any) => {
  //   })).subscribe(p => this.productList = p);
  // }

  getAllProducts() {
    this.productService.getAllProducts().subscribe((p: any) => {
      p.forEach(element => {
        element.startingDate = new Date(element.startingTime).toDateString()
        element.startingTime = new Date(element.startingTime).toTimeString();
        element.endingDate = new Date(element.endingTime).toDateString();
        element.endingTime = new Date(element.endingTime).toTimeString();
      });
      this.productList = p;
    });
  }

}
