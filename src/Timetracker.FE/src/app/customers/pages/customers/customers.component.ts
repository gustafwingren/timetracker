import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../services/customer.service';
import { CustomerDto } from '../../models/customer-dto';
import { PagedResponse } from '../../../core/models/paged-response';
import { NgIf, NgFor } from '@angular/common';
import { RouterLink } from '@angular/router';
import { ButtonComponent } from '../../../shared/button/button.component';
import { InputComponent } from '../../../shared/input/input.component';
import { PaginationComponent } from '../../../shared/pagination/pagination.component';
import { TableComponent } from '../../../shared/table/table.component';
import { TableHeader } from '../../../shared/table/tableHeader';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss'],
  standalone: true,
  imports: [
    ButtonComponent,
    RouterLink,
    NgIf,
    NgFor,
    InputComponent,
    PaginationComponent,
    TableComponent,
  ],
})
export class CustomersComponent implements OnInit {
  customers: CustomerDto[] = [];
  pageSize = 10;
  currentPage = 1;
  totalCount = 0;
  loading = true;
  searchString = '';
  tableHeaders: TableHeader[] = [
    { fieldName: 'name', displayName: 'Name', bold: true },
    { fieldName: 'number', displayName: 'Number' },
    { fieldName: 'actions', displayName: '', actions: true },
  ];

  constructor(private customerService: CustomerService) {}

  ngOnInit(): void {
    this.getCustomers();
  }

  previousPage(): void {
    this.currentPage--;
    this.getCustomers();
  }

  nextPage(): void {
    this.currentPage++;
    this.getCustomers();
  }

  search(event: Event): void {
    this.searchString = (event.target as HTMLInputElement).value;
    this.currentPage = 1;
    this.getCustomers();
  }

  getCustomers(): void {
    this.loading = true;
    this.customerService
      .getCustomers(this.searchString, this.currentPage, this.pageSize)
      .subscribe((pagedResponse: PagedResponse<CustomerDto>) => {
        this.customers = pagedResponse.items;
        this.totalCount = pagedResponse.totalCount;
        this.loading = false;
      });
  }

  protected readonly event = event;
}
