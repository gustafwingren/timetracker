import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../services/customer.service';
import { CustomerDto } from '../../models/customer-dto';
import { map } from 'rxjs';
import { PagedResponse } from '../../../core/models/paged-response';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss'],
})
export class CustomersComponent implements OnInit {
  customers: CustomerDto[] = [];
  pageSize = 1;
  currentPage = 1;
  totalCount = 0;
  loading = true;

  constructor(private customerService: CustomerService) {}

  ngOnInit(): void {
    this.getCustomers();
  }

  previousPage(): void {
    this.getCustomers();
    this.currentPage--;
  }

  nextPage(): void {
    this.getCustomers();
    this.currentPage++;
  }

  getCustomers(): void {
    this.loading = true;
    this.customerService
      .getCustomers(this.currentPage, this.pageSize)
      .subscribe((pagedResponse: PagedResponse<CustomerDto>) => {
        this.customers = pagedResponse.items;
        this.totalCount = pagedResponse.totalCount;
        this.loading = false;
      });
  }
}
