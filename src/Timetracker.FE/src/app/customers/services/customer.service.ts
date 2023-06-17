import { Injectable } from '@angular/core';
import { ApiService } from '../../core/services/api.service';
import { Observable } from 'rxjs';
import { CustomerDto } from '../models/customer-dto';
import { protectedResources } from '../../auth-config';
import { ActivityDto } from '../models/activity-dto';
import { CustomerCreateDto } from '../models/customer-create-dto';
import { PagedResponse } from '../../core/models/paged-response';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  url = protectedResources.apiCustomers.endpoint;

  constructor(private apiService: ApiService) {}

  getCustomers(
    searchString: string,
    page: number,
    pageSize: number
  ): Observable<PagedResponse<CustomerDto>> {
    return this.apiService.get(
      this.url +
        '?searchString=' +
        searchString +
        '&page=' +
        page +
        '&pageSize=' +
        pageSize
    );
  }

  getCustomer(id: string): Observable<CustomerDto> {
    return this.apiService.get(this.url + id);
  }

  addCustomer(customer: CustomerCreateDto): Observable<CustomerDto> {
    return this.apiService.post<CustomerDto>(this.url, customer);
  }

  updateCustomer(
    id: string,
    customer: CustomerCreateDto
  ): Observable<CustomerDto> {
    return this.apiService.put(this.url + id, customer);
  }

  deleteCustomer(id: string): Observable<void> {
    return this.apiService.delete(this.url + id);
  }

  getActivity(customerId: string, activityId: string): Observable<ActivityDto> {
    return this.apiService.get(
      this.url + customerId + '/activity/' + activityId
    );
  }
}
