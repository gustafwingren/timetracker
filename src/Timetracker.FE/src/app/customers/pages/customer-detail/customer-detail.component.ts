import { Component, OnInit } from '@angular/core';
import { CustomerDto } from '../../models/customer-dto';
import { ActivatedRoute, Router } from '@angular/router';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { CustomerCreateDto } from '../../models/customer-create-dto';
import { CustomerService } from '../../services/customer.service';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.scss'],
})
export class CustomerDetailComponent implements OnInit {
  customer!: CustomerDto;
  customerForm!: FormGroup<{
    name: FormControl<string | null>;
    number: FormControl<string | null>;
  }>;
  loadingUpdate = false;
  loadingDelete = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private customerService: CustomerService
  ) {}

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.customer = data['customer'];
      this.customerForm = this.formBuilder.group({
        name: [this.customer.name, Validators.required],
        number: [this.customer.number, Validators.required],
      });
    });
  }

  onSubmit() {
    this.loadingUpdate = true;
    const customer: CustomerCreateDto = {
      name: this.customerForm.controls.name.value ?? '',
      number: this.customerForm.controls.number.value ?? '',
    };

    this.customerService
      .updateCustomer(this.customer.id, customer)
      .subscribe(() => {
        this.loadingUpdate = false;
      });
  }

  onDelete() {
    this.loadingDelete = true;
    this.customerService.deleteCustomer(this.customer.id).subscribe(() => {
      this.loadingDelete = false;
      this.router.navigateByUrl('/customers');
    });
  }
}
