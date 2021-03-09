import { AbstractControl, FormGroup, ValidatorFn } from '@angular/forms';

export function emailAlreadyExist(self: any): ValidatorFn {
  return (control: AbstractControl): { [key: string]: any } | null => {
    return new Promise(resolve => {
      self.authService.emailExist(control.value).subscribe(value => {
        if (value) {
          resolve({ userExist: 'true' });
        }
        resolve(null);
      });
    });
  };
}

export function dateValidate(): ValidatorFn {
  return (control: AbstractControl): { [key: string]: any } | null => {
    const endDate = new Date(control.parent?.controls['endingDate']?.value);
    const startTime = control.parent?.controls['startingTime']?.value;
    const endingTime = control.parent?.controls['endingTime']?.value;
    const startDate = new Date(control.parent?.controls['startingDate']?.value);

    const dateNow = new Date();

    // Move this data creation to seperate method where it can be reused.
    const startDateObj = new Date(
      startDate.getFullYear(),
      startDate.getMonth(),
      startDate.getDate(),
      parseInt(startTime?.split(':')[0], 10),
      parseInt(startTime?.split(':')[1], 10)
    );

    const endDateObj = new Date(
      endDate.getFullYear(),
      endDate.getMonth(),
      endDate.getDate(),
      parseInt(endingTime?.split(':')[0], 10),
      parseInt(endingTime?.split(':')[1], 10)
    );

    if (endDateObj < startDateObj || endDateObj < dateNow) {
      return { dateError: 'true' };
    }

    return null;
  };
}
