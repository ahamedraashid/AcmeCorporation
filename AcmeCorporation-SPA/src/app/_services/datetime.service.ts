import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DatetimeService {

constructor() { }
  mergeDateAndTime(date: string, time: string): Date {
    let dateObj = new Date(date);
    let timeObj = new Date(dateObj.getFullYear(), dateObj.getMonth(), dateObj.getDate(),
                            parseInt(time.split(':')[0], 10),
                            parseInt(time.split(':')[1], 10));
    // dateObj.setHours(timeObj.getHours());
    // dateObj.setMinutes(timeObj.getMinutes());
    return timeObj;
  }

  splitDateAndTime(date: Date) {
    return {
      date: date.toISOString().slice(0,10),
      time: date.getHours() + ':' + date.getMinutes()
    }
  }
}



