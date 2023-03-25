import { Component, Input } from '@angular/core';
import { SpinnerIconColor } from './spinner-icon-color';
import { SpinnerIconSize } from './spinner-icon-size';

@Component({
  selector: 'app-spinner-icon',
  templateUrl: './spinner-icon.component.html',
  styleUrls: ['./spinner-icon.component.scss'],
})
export class SpinnerIconComponent {
  @Input() color: SpinnerIconColor = SpinnerIconColor.primary;
  @Input() size: SpinnerIconSize = SpinnerIconSize.medium;

  spinnerIconColor = SpinnerIconColor;
  spinnerIconSize = SpinnerIconSize;
}
