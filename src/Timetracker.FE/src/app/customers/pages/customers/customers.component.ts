import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../services/customer.service';
import { CustomerDto } from '../../models/customer-dto';
import { PagedResponse } from '../../../core/models/paged-response';
import {
  NgIf,
  NgFor,
  NgSwitch,
  NgSwitchCase,
  NgSwitchDefault,
} from '@angular/common';
import { RouterLink } from '@angular/router';
import { ButtonComponent } from '../../../shared/button/button.component';
import { InputComponent } from '../../../shared/input/input.component';
import { PaginationComponent } from '../../../shared/pagination/pagination.component';
import { TableComponent } from '../../../shared/table/table.component';
import { TableHeader } from '../../../shared/table/tableHeader';
import { ButtonColor } from '../../../shared/button/button-color';
import { PlusIconComponent } from '../../../shared/icons/plus-icon/plus-icon.component';
import { SearchIconComponent } from '../../../shared/icons/search-icon/search-icon.component';
import { SearchInputComponent } from '../../../shared/search-input/search-input.component';

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
    NgSwitch,
    NgSwitchCase,
    NgSwitchDefault,
    PlusIconComponent,
    SearchIconComponent,
    SearchInputComponent,
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
    { fieldName: 'name', displayName: 'Name' },
    { fieldName: 'number', displayName: 'Number' },
    { fieldName: 'actions', displayName: '' },
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

  search(searchString: string): void {
    this.searchString = searchString;
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
  protected readonly ButtonColor = ButtonColor;
}
