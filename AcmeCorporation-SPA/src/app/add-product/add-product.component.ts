import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { baseUrl } from '../constants';
import { dateValidate } from '../customValidation';
import { AlertifyService } from '../_services/alertify.service';
import { DatetimeService } from '../_services/datetime.service';
import { ProductService } from '../_services/product.service';

declare var jQuery: any;
@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss'],
})
export class AddProductComponent implements OnInit {
  files: File[];
  productId: number;
  product: any;
  editMode = false;
  baseUrl = baseUrl;
  fileChanged = false;
  addProductForm: FormGroup;
  imageUrl = [];
  constructor(
    private dateTimeService: DatetimeService,
    private productService: ProductService,
    private alertifyService: AlertifyService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    this.addProductForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
      description: new FormControl(''),
      startingBid: new FormControl('', [Validators.min(0)]),
      startingDate: new FormControl('', [
        Validators.required,
        dateValidate()
      ]),
      startingTime: new FormControl('', [Validators.required, dateValidate()]),
      endingDate: new FormControl('', [Validators.required, dateValidate()]),
      endingTime: new FormControl('', [Validators.required, dateValidate()]),
    });

    this.activatedRoute.params.subscribe((s: any) => {
      if (typeof s.id !== 'undefined') {
        this.editMode = true;
        this.productId = parseInt(s.id, 10);
      }
    });
    if (this.editMode) {
      this.setProductProperties(this.productId);
    }
  }

  setProductProperties(id: number) {
    let product;
    this.productService.getProductById(id).subscribe((s: any) => {
      this.product = s;
      let startingValues = this.dateTimeService.splitDateAndTime(
        new Date(s.startingTime)
      );
      let endingValues = this.dateTimeService.splitDateAndTime(
        new Date(s.endingTime)
      );

      this.addProductForm.patchValue({
        name: s.name,
        description: s.description === 'null' ? '' : s.description,
        startingBid: s.initialBid,
        startingDate: startingValues.date,
        startingTime: startingValues.time,
        endingDate: endingValues.date,
        endingTime: endingValues.time,
      });
    });
    this.addProductForm.get('startingBid');
  }
  onSelectFile(event) {
    this.files = event.target.files;
    this.imageUrl = [];
    this.fileChanged = true;
    // tslint:disable-next-line: prefer-for-of
    for (let i = 0; i < this.files?.length; i++) {
      if (this.files[i].type.indexOf('image') === -1) {
        this.clearUploadedImages();
      } else {
        let reader = new FileReader();
        reader.onload = (event: any) => {
          this.imageUrl.push(event.target.result);
        };
        reader.readAsDataURL(this.files[i]);
      }
    }
  }

  setStartAuction(value) {

  }
  clearUploadedImages() {
    jQuery('#file-uploader').val('');
    this.files = [];
  }

  public get getFiles() {
    return this.files;
  }
  get getInitialBidValue() {
    return this.addProductForm.get('startingBid');
  }
  get getProductName() {
    return this.addProductForm.get('name');
  }

  get getStartAuctionTime() {
    console.log(this.addProductForm.get('startAuctionNow').value);
    return this.addProductForm.get('startAuctionNow').value;
  }

  addProduct() {
    this.addProductForm.markAllAsTouched();
    if (this.addProductForm.invalid) {
      return;
    }

    // console.log(startingDate);
    const startingTime = this.addProductForm.get('startingTime').value;
    const startingDate = this.addProductForm.get('startingDate').value;
    const endingTime = this.addProductForm.get('endingTime').value;
    const endingDate = this.addProductForm.get('endingDate').value;
    const initialBid = this.addProductForm.get('startingBid').value;

    const formData = new FormData();

    for (let i = 0; i < this.files?.length; i++) {
      formData.append('Photos', this.files[i], this.files[i].name);
    }

    formData.append('Name', this.addProductForm.get('name').value);
    formData.append(
      'Description',
      this.addProductForm.get('description').value
    );
    formData.append(
      'InitialBid',
      initialBid === null || initialBid === '' ? 0 : initialBid
    );
    formData.append(
      'StartingTime',
      this.dateTimeService
        .mergeDateAndTime(startingDate, startingTime)
        .toISOString()
    );

    formData.append(
      'EndingTime',
      this.dateTimeService
        .mergeDateAndTime(endingDate, endingTime)
        .toISOString()
    );

    if (this.editMode) {
      formData.append('IsFileModified', this.fileChanged.toString());
      formData.append('Id', this.product.id);

      this.productService.updateProduct(formData).subscribe(
        (next) => {
          this.alertifyService.success('Product has been updated successfully!');
          this.router.navigate(['/admin']);
        },
        (error) =>
          this.alertifyService.error(
            'Something went wrong while updating the product'
          )
      );
    } else {
      this.productService.addProduct(formData).subscribe(
        (next) => {
          this.alertifyService.success('Product added successfully!');
          this.router.navigate(['/admin']);
        },
        (error) =>
          this.alertifyService.error(
            'Something went wrong while saving the product'
          )
      );
    }
  }
}
