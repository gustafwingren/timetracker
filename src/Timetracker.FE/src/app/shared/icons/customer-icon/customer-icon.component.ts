import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-customer-icon',
  templateUrl: './customer-icon.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
  standalone: true,
})
export class CustomerIconComponent {}
