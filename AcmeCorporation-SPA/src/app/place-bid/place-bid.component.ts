import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

declare const jQuery: any;
@Component({
  selector: 'app-place-bid',
  templateUrl: './place-bid.component.html',
  styleUrls: ['./place-bid.component.scss'],
})
export class PlaceBidComponent implements OnInit {
  @Input() currentBid: number;
  @Output() updateAmount = new EventEmitter<number>();

  placeBidForm: FormGroup;
  constructor() {}

  ngOnInit() {
    console.log(this.currentBid);
    if (this.currentBid) {
      this.addPlaceBidFormValidation(this.currentBid);
    }
  }
  addPlaceBidFormValidation(currentBid: number) {
    this.placeBidForm = new FormGroup({
      amount: new FormControl('', [
        Validators.required,
        Validators.min(currentBid + 1),
      ]),
    });
  }
  placeBid() {
    this.placeBidForm.markAllAsTouched();
    if (this.placeBidForm.invalid) {
      return;
    }
    this.updateAmount.emit(this.getAmount.value);
  }

  get getAmount() {
    return this.placeBidForm.get('amount');
  }
  closePlaceBidModal() {
    jQuery('#placeBidModal').modal('hide');
  }
}
