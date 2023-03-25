import { Component } from '@angular/core';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { CustomerCreateDto } from '../../models/customer-create-dto';
import { CustomerService } from '../../services/customer.service';
import { firstValueFrom } from 'rxjs';
import { ActivityCreateDto } from '../../models/activity-create-dto';
import { SpinnerIconColor } from '../../../shared/spinner-icon/spinner-icon-color';
import { SpinnerIconSize } from '../../../shared/spinner-icon/spinner-icon-size';
import { CustomerDto } from '../../models/customer-dto';

@Component({
  selector: 'app-customer-new',
  templateUrl: './customer-new.component.html',
  styleUrls: ['./customer-new.component.scss'],
})
export class CustomerNewComponent {
  newestCreatedCustomer?: CustomerDto;
  customerForm = this.formBuilder.group({
    name: ['', Validators.required],
    number: ['', Validators.required],
    activities: this.formBuilder.array([]),
  });
  loading = false;
  spinnerIconColor = SpinnerIconColor;
  spinnerIconSize = SpinnerIconSize;

  get activities() {
    return this.customerForm.get('activities') as FormArray<FormControl>;
  }

  constructor(
    private formBuilder: FormBuilder,
    private customerService: CustomerService
  ) {}

  addActivity() {
    const activityForm = this.formBuilder.control('', Validators.required);

    this.activities.push(activityForm);
  }

  removeActivity(index: number) {
    this.activities.removeAt(index);
  }

  onSubmit() {
    this.loading = true;
    const customer: CustomerCreateDto = {
      name: this.customerForm.controls.name.value ?? '',
      number: this.customerForm.controls.number.value ?? '',
      activities: this.activities.controls.map(x => {
        const activity: ActivityCreateDto = {
          name: x.value ?? '',
        };
        return activity;
      }),
    };

    this.customerService.addCustomer(customer).subscribe(createdCustomer => {
      this.loading = false;

      if (createdCustomer) {
        this.newestCreatedCustomer = createdCustomer;
        this.customerForm = this.formBuilder.group({
          name: ['', Validators.required],
          number: ['', Validators.required],
          activities: this.formBuilder.array([]),
        });
        return;
      }
      console.log('error');
      // show errormessage
    });
  }
}
