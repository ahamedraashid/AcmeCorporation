import { ChangeDetectorRef, Component, ElementRef, EventEmitter, HostListener, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MdbTableDirective, MdbTablePaginationComponent } from 'angular-bootstrap-md';

@Component({
  selector: 'app-datatable',
  templateUrl: './datatable.component.html',
  styleUrls: ['./datatable.component.scss']
})
export class DatatableComponent implements OnInit {

  @ViewChild(MdbTableDirective, { static: true }) mdbTable: MdbTableDirective;
  @ViewChild(MdbTablePaginationComponent, { static: true }) mdbTablePagination: MdbTablePaginationComponent;
  @ViewChild('row', { static: true }) row: ElementRef;

  elements: any = [];
  @Input() headElements: any;
  @Input() itemList: any;
  productId: number;
  searchText  = '';
  previous: string;

  maxVisibleItems = 8;

  constructor(private cdRef: ChangeDetectorRef) {}

  @HostListener('input') oninput() {
    this.mdbTablePagination.searchText = this.searchText;
  }

  ngOnInit() {
    // for (let i = 1; i <= 25; i++) {
    //   this.elements.push({id: i.toString(), first: 'Wpis ' + i, last: 'Last ' + i, handle: 'Handle ' + i});
    // }
    console.log(this.itemList);
    this.elements = this.itemList;

    this.mdbTable.setDataSource(this.elements);
    this.elements = this.mdbTable.getDataSource();
    this.previous = this.mdbTable.getDataSource();
  }

  // tslint:disable-next-line: use-lifecycle-interface
  ngAfterViewInit() {
    this.mdbTablePagination.setMaxVisibleItemsNumberTo(this.maxVisibleItems);

    this.mdbTablePagination.calculateFirstItemIndex();
    this.mdbTablePagination.calculateLastItemIndex();
    this.cdRef.detectChanges();
  }

  // addNewRow() {
  //   this.mdbTable.addRow({
  //     id: this.elements.length.toString(),
  //     first: 'Wpis ' + this.elements.length,
  //     last: 'Last ' + this.elements.length,
  //     handle: 'Handle ' + this.elements.length
  //   });
  //   this.emitDataSourceChange();
  // }

  // addNewRowAfter() {
  //   this.mdbTable.addRowAfter(1, {id: '2', first: 'Nowy', last: 'Row', handle: 'Kopytkowy'});
  //   this.mdbTable.getDataSource().forEach((el: any, index: any) => {
  //     el.id = (index + 1).toString();
  //   });
  //   this.emitDataSourceChange();
  // }

  // removeLastRow() {
  //   this.mdbTable.removeLastRow();
  //   this.emitDataSourceChange();
  //   this.mdbTable.rowRemoved().subscribe((data: any) => {
  //     console.log(data);
  //   });
  // }

  // removeRow() {
  //   this.mdbTable.removeRow(1);
  //   this.mdbTable.getDataSource().forEach((el: any, index: any) => {
  //     el.id = (index + 1).toString();
  //   });
  //   this.emitDataSourceChange();
  //   this.mdbTable.rowRemoved().subscribe((data: any) => {
  //     console.log(data);
  //   });
  // }

  emitDataSourceChange() {
    this.mdbTable.dataSourceChange().subscribe((data: any) => {
      console.log(data);
    });
  }

  searchItems() {
    const prev = this.mdbTable.getDataSource();

    if (!this.searchText) {
      this.mdbTable.setDataSource(this.previous);
      this.elements = this.mdbTable.getDataSource();
    }

    if (this.searchText) {
      this.elements = this.mdbTable.searchLocalDataBy(this.searchText);
      this.mdbTable.setDataSource(prev);
    }

    this.mdbTablePagination.calculateFirstItemIndex();
    this.mdbTablePagination.calculateLastItemIndex();

    this.mdbTable.searchDataObservable(this.searchText).subscribe(() => {
      this.mdbTablePagination.calculateFirstItemIndex();
      this.mdbTablePagination.calculateLastItemIndex();
    });
  }

  initProductDeleteModal(productId: number) {
    this.productId = productId;
  }

  deleteProductIdRow(productId: number) {
    this.itemList.forEach((item, index) => {
      if (item.id === productId) {
        this.itemList.splice(index, 1);
      }
   });
  }
}
