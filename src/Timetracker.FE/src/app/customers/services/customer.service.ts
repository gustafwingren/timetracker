import { Injectable } from '@angular/core';
import { ApiService } from '../../core/services/api.service';
import { Observable } from 'rxjs';
import { CustomerDto } from '../models/customer-dto';
import { protectedResources } from '../../auth-config';
import { ActivityDetailComponent } from '../pages/activity-detail/activity-detail.component';
import { ActivityDto } from '../models/activity-dto';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  url = protectedResources.apiCustomers.endpoint;

  constructor(private apiService: ApiService) {}

  getCustomers(): Observable<CustomerDto[]> {
    return this.apiService.get(this.url);
  }

  getCustomer(id: string): Observable<CustomerDto> {
    return this.apiService.get(this.url + id);
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
