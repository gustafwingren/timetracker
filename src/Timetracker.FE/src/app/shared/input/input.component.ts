import { Component } from '@angular/core';

@Component({
  // eslint-disable-next-line @angular-eslint/component-selector
  selector: 'input[appInput]',
  template: '<ng-content></ng-content>',
  styleUrls: ['./input.component.scss'],
  standalone: true,
})
export class InputComponent {}
