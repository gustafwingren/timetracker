import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CustomerIconComponent } from '../icons/customer-icon/customer-icon.component';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-side-menu',
  templateUrl: './side-menu.component.html',
  styleUrls: ['./side-menu.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  standalone: true,
  imports: [RouterLink, RouterLinkActive, CustomerIconComponent],
})
export class SideMenuComponent {}
