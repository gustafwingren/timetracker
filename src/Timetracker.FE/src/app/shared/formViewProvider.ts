import { ControlContainer, NgForm, NgModelGroup } from '@angular/forms';
import { Optional } from '@angular/core';

export const FormViewProvider = {
  provide: ControlContainer,
  useFactory: _formViewProviderFactory,
  deps: [
    [new Optional(), NgForm],
    [new Optional(), NgModelGroup],
  ],
};

export function _formViewProviderFactory(
  ngForm: NgForm,
  ngModelGroup: NgModelGroup
) {
  return ngForm || ngModelGroup || null;
}
