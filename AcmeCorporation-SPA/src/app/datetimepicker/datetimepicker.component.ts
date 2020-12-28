import { Component, Input, OnInit } from '@angular/core';
import { ControlContainer, FormGroup, FormGroupDirective } from '@angular/forms';

@Component({
  selector: 'app-datetimepicker',
  templateUrl: './datetimepicker.component.html',
  styleUrls: ['./datetimepicker.component.scss'],
  viewProviders: [
    {
      provide: ControlContainer,
      useExisting: FormGroupDirective
    }
  ]
})
export class DatetimepickerComponent implements OnInit {

  @Input() form: FormGroup;
  constructor() { }

  ngOnInit() {

  }

}
