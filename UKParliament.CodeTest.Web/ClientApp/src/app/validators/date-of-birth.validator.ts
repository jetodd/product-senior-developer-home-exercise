import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function dateValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const today = new Date().toISOString();

    if (!(control && control.value)) {
      return null;
    }

    const dateToCheck = new Date(control.value);

    return dateToCheck.toISOString() > today
      ? { invalidDate: 'You cannot use future dates' }
      : null;
  };
}
