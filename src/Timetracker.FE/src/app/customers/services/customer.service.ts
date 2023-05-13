import { Injectable } from '@angular/core';
import { ApiService } from '../../core/services/api.service';
import { flatMap, forkJoin, map, mergeMap, Observable, of } from 'rxjs';
import { CustomerDto } from '../models/customer-dto';
import { protectedResources } from '../../auth-config';
import { ActivityDetailComponent } from '../pages/activity-detail/activity-detail.component';
import { ActivityDto } from '../models/activity-dto';
import { CustomerCreateDto } from '../models/customer-create-dto';
import { ActivityCreateDto } from '../models/activity-create-dto';
import { PagedResponse } from '../../core/models/paged-response';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  url = protectedResources.apiCustomers.endpoint;

  constructor(private apiService: ApiService) {}

  getCustomers(
    page: number,
    pageSize: number
  ): Observable<PagedResponse<CustomerDto>> {
    return this.apiService.get(
      this.url + '?page=' + page + '&pageSize=' + pageSize
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
