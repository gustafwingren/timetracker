import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-button-primary',
  templateUrl: './button-primary.component.html',
  styleUrls: ['./button-primary.component.scss'],
})
export class ButtonPrimaryComponent {
  @Input() type = 'button';
  @Input() text = '';
  @Input() loading = false;
  @Input() disabled = false;
  @Output() clickEvent: EventEmitter<Event> = new EventEmitter<Event>();
}
