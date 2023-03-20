import { inject } from '@angular/core';
import { Router, ActivatedRouteSnapshot, ResolveFn } from '@angular/router';
import { EMPTY, mergeMap, of } from 'rxjs';
import { CustomerDto } from '../../models/customer-dto';
import { CustomerService } from '../../services/customer.service';

export const customerDetailResolver: ResolveFn<CustomerDto> = (
  route: ActivatedRouteSnapshot
) => {
  const router = inject(Router);
  const cs = inject(CustomerService);
  const id = route.paramMap.get('id')!;

  return cs.getCustomer(id).pipe(
    mergeMap(customer => {
      if (customer) {
        return of(customer);
      } else {
        // id not found
        router.navigate(['/customers']);
        return EMPTY;
      }
    })
  );
};
