import { Time } from '@angular/common';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { interval } from 'rxjs/internal/observable/interval';
import { map } from 'rxjs/operators';
import { DatetimeService } from './datetime.service';

@Injectable({
  providedIn: 'root',
})
export class TimerService {
  private diff: number;
  private days: number;
  private hours: number;
  private minutes: number;
  private seconds: number;
  constructor() {}

  // timer(endDate: string) {
  //   return interval(1000)
  //     .pipe(
  //       map((x) => {
  //         let time: Time = {days: 0, hours: 0, minutes: 0, seconds: 0};
  //         this.diff = Date.parse(endDate) - Date.parse(new Date().toString());
  //         this.days = this.getDays(this.diff);
  //         this.hours = this.getHours(this.diff);
  //         this.minutes = this.getMinutes(this.diff);
  //         this.seconds = this.getSeconds(this.diff);
  //       }));
  // }

  private createTimeObject(startingTime: Date, endingTime: Date) {
    let distance;
    let dateNow = new Date();
    // let inputTime = date.getTime();
    if (startingTime < dateNow && endingTime > dateNow) {
      distance = endingTime.getTime() - dateNow.getTime();
    } else if (startingTime > dateNow){
      distance = startingTime.getTime() - dateNow.getTime();
    }
    // if (inputTime > dateNow) {
      // distance = inputTime - dateNow;
    // } else {
      // distance = dateNow - inputTime;
    // }
    // distance = inputTime - dateNow;
    console.log(distance);
    let array = new Array();
    array.push(Math.floor(distance / (1000 * 60 * 60 * 24)) + ' Days ');
    array.push(
      Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60)) +
        ' Hours '
    );
    array.push(
      Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60)) + ' Minutes '
    );
    array.push(Math.floor((distance % (1000 * 60)) / 1000) + ' Seconds');
    return array.join(':');
  }


  // getUTCNow() {
  //   let now = new Date();
  //   let time = now.getTime();
  //   let offset = now.getTimezoneOffset();
  //   offset = offset * 60000;
  //   return time - offset;
  // }

  timer(startingDate: Date, endingDate: Date) {
    return interval(1000).pipe(map(() => this.createTimeObject(startingDate, endingDate)));
  }

  // private getDays(t) {
  //   return Math.floor(t / (1000 * 60 * 60 * 24));
  // }

  // private getHours(t) {
  //   return Math.floor((t / (1000 * 60 * 60)) % 24);
  // }

  // private getMinutes(t) {
  //   return Math.floor((t / 1000 / 60) % 60);
  // }

  // private getSeconds(t) {
  //   return Math.floor((t / 1000) % 60);
  // }
}
