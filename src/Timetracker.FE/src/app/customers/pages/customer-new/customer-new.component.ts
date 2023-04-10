import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CustomerCreateDto } from '../../models/customer-create-dto';
import { CustomerService } from '../../services/customer.service';
import { ActivityCreateDto } from '../../models/activity-create-dto';
import { CustomerDto } from '../../models/customer-dto';
import { ButtonColor } from '../../../shared/button/button-color';

@Component({
  selector: 'app-customer-new',
  templateUrl: './customer-new.component.html',
  styleUrls: ['./customer-new.component.scss'],
})
export class CustomerNewComponent {
  newestCreatedCustomer?: CustomerDto;
  model: CustomerForm = {
    name: '',
    number: '',
  };

  errors: { field: string; error: string }[] = [];
  hasError = false;
  loading = false;

  @ViewChild(NgForm) form!: NgForm;

  constructor(private customerService: CustomerService) {}

  addActivity() {
    if (this.model.activities === undefined) {
      this.model.activities = [];
    }

    this.model.activities.push({
      name: '',
      id: Date.now().toString(),
    });
  }

  removeActivity(activityId: string) {
    this.model.activities = this.model.activities?.filter(
      x => x.id !== activityId
    );
  }

  onSubmit() {
    this.loading = true;
    this.hasError = false;
    this.errors = [];
    const customer: CustomerCreateDto = {
      name: this.model.name,
      number: this.model.number,
      activities: this.model.activities?.map(x => {
        const activity: ActivityCreateDto = {
          name: x.name,
        };
        return activity;
      }),
    };

    this.customerService.addCustomer(customer).subscribe(
      createdCustomer => {
        this.loading = false;

        if (createdCustomer) {
          this.newestCreatedCustomer = createdCustomer;
          this.model = {
            name: '',
            number: '',
          };
          return;
        }
      },
      error => {
        this.loading = false;
        if (error.status == 400) {
          this.hasError = true;
          this.errors = error.response;
        }
      }
    );
  }

  containsError(field: string): boolean {
    return this.errors.some(error => error.field === field);
  }

  errorsForField(field: string): string[] {
    return this.errors
      .filter(error => error.field === field)
      .map(error => error.error);
  }

  protected readonly ButtonColor = ButtonColor;
}
interface CustomerForm {
  name: string;
  number: string;
  activities?: ActivityForm[];
}

interface ActivityForm {
  name: string;
  id: string;
}
