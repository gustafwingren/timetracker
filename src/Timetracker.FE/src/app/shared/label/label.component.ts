import { Component } from '@angular/core';

@Component({
  selector: 'app-label',
  template: '<ng-content></ng-content>',
  styleUrls: ['./label.component.scss'],
  standalone: true,
})
export class LabelComponent {}
