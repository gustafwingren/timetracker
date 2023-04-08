import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { FormViewProvider } from '../formViewProvider';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  viewProviders: [FormViewProvider],
  styleUrls: ['./input.component.scss'],
})
export class InputComponent {
  @Input() name!: string;
  @Input() placeholder = '';
  @Input() value = '';
  @Output() valueChange: EventEmitter<string> = new EventEmitter<string>();
  @Input() isRequired = false;
  @Input() serverValidationFailed = false;
  @Input() serverValidationErrors: string[] = [];
}
