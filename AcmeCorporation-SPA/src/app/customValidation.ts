import { AbstractControl, FormGroup, ValidatorFn } from '@angular/forms';

export function startDateValidate(): ValidatorFn {
  return (control: AbstractControl): { [key: string]: any } | null => {
    const date = new Date(control.value);
    if (date < new Date()) {
      return { startDateError: 'true' };
    }
    return null;
  };
}

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

export function endDateValidate(): ValidatorFn {
  return (control: AbstractControl): { [key: string]: any } | null => {
    const endDate = new Date(control.parent?.controls['endingDate']?.value);
    const startTime = control.parent?.controls['startingTime']?.value;
    const endingTime = control.parent?.controls['endingTime']?.value;
    const startDate = new Date(control.parent?.controls['startingDate']?.value);

    const dateNow = new Date();
    let startDatePObj = new Date(
      startDate.getFullYear(),
      startDate.getMonth(),
      startDate.getDate(),
      parseInt(startTime?.split(':')[0], 10),
      parseInt(startTime?.split(':')[1], 10)
    );

    let endDateObj = new Date(
      endDate.getFullYear(),
      endDate.getMonth(),
      endDate.getDate(),
      parseInt(endingTime?.split(':')[0], 10),
      parseInt(endingTime?.split(':')[1], 10)
    );
    if (endDateObj < startDatePObj || endDateObj < dateNow) {
      return { endDateError: 'true' };
    }
    return null;
  };
}
