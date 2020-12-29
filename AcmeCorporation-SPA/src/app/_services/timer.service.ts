import { Injectable } from '@angular/core';
import { interval } from 'rxjs/internal/observable/interval';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class TimerService {
  constructor() {}
  private createTimeObject(startingTime: Date, endingTime: Date) {
    let distance;
    let dateNow = new Date();
    if (startingTime < dateNow && endingTime > dateNow) {
      distance = endingTime.getTime() - dateNow.getTime();
    } else if (startingTime > dateNow){
      distance = startingTime.getTime() - dateNow.getTime();
    }
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

  timer(startingDate: Date, endingDate: Date) {
    return interval(1000).pipe(map(() => this.createTimeObject(startingDate, endingDate)));
  }
}
