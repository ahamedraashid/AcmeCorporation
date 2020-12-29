import {
  Component,
  OnInit,
  ViewChild,
} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { baseUrl } from '../constants';
import { ProductStatus } from '../enums';
import { PlaceBidComponent } from '../place-bid/place-bid.component';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';
import { DatetimeService } from '../_services/datetime.service';
import { ProductService } from '../_services/product.service';
import { TimerService } from '../_services/timer.service';
import { TransactionService } from '../_services/transaction.service';

declare const jQuery: any;
@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss'],
})
export class ProductDetailsComponent implements OnInit {
  baseUrl = baseUrl;
  product: any;
  timerString: Observable<string>;
  productStatus: ProductStatus;
  productStatusEnum = ProductStatus;
  timerStringSubscriberObject: any;
  @ViewChild(PlaceBidComponent) placeBidComponent: PlaceBidComponent;
  constructor(
    private dateTimeService: DatetimeService,
    private productService: ProductService,
    private alertifyService: AlertifyService,
    private authServive: AuthService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private timerService: TimerService,
    private transactionService: TransactionService
  ) {}

  ngOnInit() {
    this.activatedRoute.params.subscribe((s: any) => {
      if (typeof s.id !== 'undefined') {
        this.productService.getProductById(s.id).subscribe((product: any) => {
          this.product = product;
          this.timerString = this.timerService.timer(
            this.startingTimeObject,
            this.endingTimeObject
          );
          this.timeStringSubscribe();
        });
      }
    });
  }

  get startingTimeObject() {
    return new Date(this.product.startingTime);
  }

  setProductStatus(value: ProductStatus) {
    if (value !== this.productStatus) {
      this.productStatus = value;
      let product = {
        Id: this.product.id,
        Status: this.productStatus.toString()
      }
      this.productService.updateProductStatus(product).subscribe();
    }
  }

  get endingTimeObject() {
    return new Date(this.product.endingTime);
  }

  openPlaceBidModal() {
    if (this.authServive.loggedIn()) {
      jQuery('#placeBidModal').modal('show');
    } else {
      this.alertifyService.error('Please login to place bids.');
    }
    this.placeBidComponent.addPlaceBidFormValidation(this.product.highestBid);
  }

  timeStringSubscribe() {
    this.timerStringSubscriberObject = this.timerString.subscribe((s) => {
      let dateNow = new Date();
      if (
        this.startingTimeObject < dateNow &&
        this.endingTimeObject > dateNow
      ) {
        this.setProductStatus(ProductStatus.Active);
        this.productStatus = ProductStatus.Active;
      } else if (this.startingTimeObject > dateNow) {
        this.setProductStatus(ProductStatus.Inactive);
      } else if (this.endingTimeObject < dateNow) {
        if (this.product.transactionCount > 0) {
          this.setProductStatus(ProductStatus.Sold);
        } else {
          this.setProductStatus(ProductStatus.Unsold);
        }
      }
    });
  }

  placeBid(newAmount: number) {
    let transaction = {
      productId: this.product.id,
      amount: newAmount,
    };
    this.transactionService.addTransaction(transaction).subscribe(
      (s: any) => {
        this.product.highestBid = newAmount;
        this.product.transactionCount = s.transactionCount;
        this.alertifyService.success('Placed bid successfully!');
        this.placeBidComponent.closePlaceBidModal();
      },
      (error) =>
        this.alertifyService.error(
          'Something went wrong while placing the bid!'
        )
    );
  }
}
