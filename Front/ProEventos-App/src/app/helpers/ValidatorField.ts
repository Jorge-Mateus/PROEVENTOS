import { AbstractControl, FormGroup } from '@angular/forms';

export class ValidatorField {

  static MustMatch(controlName: string, MatchingControlName: string): any{
    return (group: AbstractControl)=> {
      const formGroup = group as FormGroup;
      const control = formGroup.controls[controlName];
      const MatchingControl = formGroup.controls[MatchingControlName];

      if(MatchingControl.errors && !MatchingControl.errors.mustMatch){
        return null;
      }

      if(control.value != MatchingControl.value){
        MatchingControl.setErrors({mustMatch: true});
      } else {
        MatchingControl.setErrors(null);
      }

      return null;
    };
  }
}
