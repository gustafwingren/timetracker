import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../services/customer.service';
import { CustomerDto } from '../../models/customer-dto';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss'],
})
export class CustomersComponent implements OnInit {
  customers: CustomerDto[] = [];
  loading = true;

  constructor(private customerService: CustomerService) {}

  ngOnInit(): void {
    this.getCustomers();
  }

  getCustomers(): void {
    this.customerService
      .getCustomers()
      .subscribe((customers: CustomerDto[]) => {
        this.customers = customers;
        this.loading = false;
      });
  }
}
