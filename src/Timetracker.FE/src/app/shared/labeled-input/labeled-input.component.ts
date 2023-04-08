import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-labeled-input',
  templateUrl: './labeled-input.component.html',
  styleUrls: ['./labeled-input.component.scss'],
})
export class LabeledInputComponent {
  @Input() name!: string;
  @Input() value = '';
  @Output() valueChange: EventEmitter<string> = new EventEmitter<string>();
  @Input() isRequired = false;
  @Input() serverValidationFailed = false;
  @Input() serverValidationErrors: string[] = [];
}
