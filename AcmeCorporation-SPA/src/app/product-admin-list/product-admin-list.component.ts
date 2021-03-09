import { Component, Input, OnInit } from '@angular/core';
import { ProductService } from '../_services/product.service';

declare var moment: any;
@Component({
  selector: 'app-product-admin-list',
  templateUrl: './product-admin-list.component.html',
  styleUrls: ['./product-admin-list.component.scss']
})
export class ProductAdminListComponent implements OnInit {
  @Input() loggedInAsAdmin: boolean;
  productList: any;
  headElements = ['Id', 'Name', 'Starting Bid', 'Current Bid', 'St. Time', 'End Time', 'Bid Count', 'Status'];
  constructor(private productService: ProductService) { }
  ngOnInit() {
    this.getAllProducts();
  }
  getAllProducts() {
    this.productService.getAllProducts().subscribe((p: any) => {
      p.forEach(element => {
        element.displayStartingTime = moment(element.startingTime).format(
          'LLL'
        );
        element.displayEndingTime = moment(element.endingTime).format('LLL');
      });
      this.productList = p;
    });
  }
}
