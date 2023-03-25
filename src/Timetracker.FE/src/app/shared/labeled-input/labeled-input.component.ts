import { Component, Input } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-labeled-input',
  templateUrl: './labeled-input.component.html',
  styleUrls: ['./labeled-input.component.scss'],
})
export class LabeledInputComponent {
  @Input() name!: string;
  @Input() id!: string;
  @Input() inputControl!: FormControl;
  @Input() isRequired = false;
}
