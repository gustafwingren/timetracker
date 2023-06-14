import { Component, Input } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-link',
  templateUrl: './link.component.html',
  styleUrls: ['./link.component.scss'],
  standalone: true,
  imports: [RouterLink],
})
export class LinkComponent {
  @Input() link = '';
  @Input() text = '';
  @Input() title = '';
}
