import { Component, Input } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.scss'],
})
export class InputComponent {
  @Input() name!: string;
  @Input() placeholder = '';
  @Input() id!: string;
  @Input() inputControl!: FormControl;
  @Input() isRequired = false;
}
