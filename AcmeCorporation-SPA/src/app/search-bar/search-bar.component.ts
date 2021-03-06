import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.scss']
})
export class SearchBarComponent implements OnInit {
  searchWord: string;
  @Output() searchCriteria = new EventEmitter<string>();
  searchThis() {
    this.searchCriteria.emit(this.searchWord);
  }

  constructor() { }

  ngOnInit() {
  }

}
