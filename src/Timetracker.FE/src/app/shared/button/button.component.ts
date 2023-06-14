import { Component, HostBinding, Input } from '@angular/core';
import { SpinnerIconColor } from '../spinner-icon/spinner-icon-color';
import { SpinnerIconSize } from '../spinner-icon/spinner-icon-size';
import { ButtonColor } from './button-color';
import { SpinnerIconComponent } from '../spinner-icon/spinner-icon.component';
import { NgIf } from '@angular/common';

@Component({
  // eslint-disable-next-line @angular-eslint/component-selector
  selector: 'button[app-button],a[app-button]',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss'],
  standalone: true,
  imports: [NgIf, SpinnerIconComponent],
})
export class ButtonComponent {
  @Input() color: ButtonColor = ButtonColor.Default;

  @HostBinding('class.accent')
  private get isAccent(): boolean {
    return this.color === ButtonColor.Accent;
  }

  @HostBinding('class.danger')
  private get isDanger(): boolean {
    return this.color === ButtonColor.Danger;
  }

  @Input()
  loading = false;
  spinnerIconColor: SpinnerIconColor = SpinnerIconColor.button;
  spinnerIconSize: SpinnerIconSize = SpinnerIconSize.small;
}
