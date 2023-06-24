import { Component, OnInit } from '@angular/core';
import { CustomerDto } from '../../models/customer-dto';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { FormBuilder, FormsModule } from '@angular/forms';
import { CustomerCreateDto } from '../../models/customer-create-dto';
import { CustomerService } from '../../services/customer.service';
import {
  NgFor,
  NgIf,
  NgSwitch,
  NgSwitchCase,
  NgSwitchDefault,
} from '@angular/common';
import { TableComponent } from '../../../shared/table/table.component';
import { ButtonComponent } from '../../../shared/button/button.component';
import { ButtonColor } from '../../../shared/button/button-color';
import { TableHeader } from '../../../shared/table/tableHeader';
import { FormFieldComponent } from '../../../shared/form-field/form-field.component';
import { InputComponent } from '../../../shared/input/input.component';
import { ErrorComponent } from '../../../shared/error/error.component';
import { LabelComponent } from '../../../shared/label/label.component';
import { ToastType } from '../../../core/enums/toastType';
import { ToastService } from '../../../core/services/toast.service';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.scss'],
  standalone: true,
  imports: [
    FormsModule,
    RouterLink,
    NgFor,
    TableComponent,
    NgSwitch,
    NgSwitchDefault,
    NgSwitchCase,
    ButtonComponent,
    FormFieldComponent,
    InputComponent,
    NgIf,
    ErrorComponent,
    LabelComponent,
  ],
})
export class CustomerDetailComponent implements OnInit {
  customer!: CustomerDto;
  model: CustomerForm = {
    name: '',
    number: '',
  };
  errors: { field: string; error: string }[] = [];
  hasError = false;
  loadingUpdate = false;
  loadingDelete = false;
  activitiesTableHeader: TableHeader[] = [
    { fieldName: 'name', displayName: 'Name' },
    { fieldName: 'actions', displayName: '' },
  ];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private customerService: CustomerService,
    private toastService: ToastService
  ) {}

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.customer = data['customer'];
      this.model = {
        name: this.customer.name,
        number: this.customer.number,
      };
    });
  }

  onSubmit() {
    this.loadingUpdate = true;
    this.hasError = false;
    this.errors = [];
    const customer: CustomerCreateDto = {
      name: this.model.name,
      number: this.model.number,
    };

    this.customerService.updateCustomer(this.customer.id, customer).subscribe(
      () => {
        this.toastService.addToast(
          ToastType.Success,
          'Success',
          'Customer updated successfully'
        );
        this.loadingUpdate = false;
      },
      error => {
        this.loadingUpdate = false;
        if (error.status === 400) {
          this.errors = error.response;
          this.hasError = true;
        }
      }
    );
  }

  onDelete() {
    this.loadingDelete = true;
    this.customerService.deleteCustomer(this.customer.id).subscribe(() => {
      this.loadingDelete = false;
      this.router.navigateByUrl('/customers');
    });
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
