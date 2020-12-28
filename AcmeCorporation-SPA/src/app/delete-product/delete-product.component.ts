import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { ProductService } from '../_services/product.service';

declare const jQuery: any;

@Component({
  selector: 'app-delete-product',
  templateUrl: './delete-product.component.html',
  styleUrls: ['./delete-product.component.scss']
})
export class DeleteProductComponent implements OnInit {

  @Input() productId: number;
  @Output() deletedProductId =  new EventEmitter<number>();

  constructor(private productService: ProductService, private alertifyService: AlertifyService) { }

  ngOnInit() {
  }

  deleteProduct() {
    if (this.productId) {
      this.productService.deleteProduct(this.productId).subscribe(s => {
        this.deletedProductId.emit(this.productId);
        this.hideModal();
        this.alertifyService.success('Successfully deleted product!');
      }, error =>   this.alertifyService.error('Something went wrong while deleting the product'));
    }
  }

  hideModal() {
    jQuery('#delete-modal').modal('hide');
  }
}
