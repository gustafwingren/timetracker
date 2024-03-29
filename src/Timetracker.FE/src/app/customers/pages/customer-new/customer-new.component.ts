import { Component, ViewChild } from '@angular/core';
import { NgForm, FormsModule } from '@angular/forms';
import { CustomerCreateDto } from '../../models/customer-create-dto';
import { CustomerService } from '../../services/customer.service';
import { ActivityCreateDto } from '../../models/activity-create-dto';
import { CustomerDto } from '../../models/customer-dto';
import { ButtonColor } from '../../../shared/button/button-color';
import { ButtonComponent } from '../../../shared/button/button.component';
import { ErrorComponent } from '../../../shared/error/error.component';
import { InputComponent } from '../../../shared/input/input.component';
import { LabelComponent } from '../../../shared/label/label.component';
import { FormFieldComponent } from '../../../shared/form-field/form-field.component';
import { Router, RouterLink } from '@angular/router';
import { NgIf, NgFor } from '@angular/common';
import { ModalService } from '../../../core/services/modal.service';

@Component({
  selector: 'app-customer-new',
  templateUrl: './customer-new.component.html',
  styleUrls: ['./customer-new.component.scss'],
  standalone: true,
  imports: [
    NgIf,
    RouterLink,
    FormsModule,
    FormFieldComponent,
    LabelComponent,
    InputComponent,
    ErrorComponent,
    NgFor,
    ButtonComponent,
  ],
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

  constructor(
    private customerService: CustomerService,
    private modalService: ModalService,
    private routerService: Router
  ) {}

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
          this.form.resetForm();
          this.modalService.showModal(
            'Kund tillagd',
            'Kunden är nu tillagd och du kan börja rapportera tid på kunden.',
            undefined,
            undefined,
            this.navigateToCreatedCustomer.bind(this),
            'Visa kund'
          );
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

  navigateToCreatedCustomer() {
    this.routerService.navigateByUrl(
      '/customers/' + this.newestCreatedCustomer?.id + '/edit'
    );
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
