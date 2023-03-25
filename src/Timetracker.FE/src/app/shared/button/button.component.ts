import { Component, EventEmitter, Input, Output } from '@angular/core';
import { SpinnerIconColor } from '../spinner-icon/spinner-icon-color';
import { SpinnerIconSize } from '../spinner-icon/spinner-icon-size';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss'],
})
export class ButtonComponent {
  @Input() type = 'button';
  @Input() text = '';
  @Input() color = '';
  @Input() loading = false;
  @Input() disabled = false;
  @Output() clickEvent: EventEmitter<Event> = new EventEmitter<Event>();
  spinnerIconColor: SpinnerIconColor = SpinnerIconColor.button;
  spinnerIconSize: SpinnerIconSize = SpinnerIconSize.small;
}
