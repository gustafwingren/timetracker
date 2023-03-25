import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-button-accent',
  templateUrl: './button-accent.component.html',
  styleUrls: ['./button-accent.component.scss'],
})
export class ButtonAccentComponent {
  @Input() type = 'button';
  @Input() text = '';
  @Output() clickEvent: EventEmitter<Event> = new EventEmitter<Event>();
}
