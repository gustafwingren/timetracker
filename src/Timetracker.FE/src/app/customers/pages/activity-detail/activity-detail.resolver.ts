import { inject } from '@angular/core';
import { Router, ActivatedRouteSnapshot, ResolveFn } from '@angular/router';
import { EMPTY, mergeMap, of } from 'rxjs';
import { CustomerService } from '../../services/customer.service';
import { ActivityDto } from '../../models/activity-dto';

export const activityDetailResolver: ResolveFn<ActivityDto> = (
  route: ActivatedRouteSnapshot
) => {
  const router = inject(Router);
  const cs = inject(CustomerService);
  const id = route.paramMap.get('id')!;
  const activityId = route.paramMap.get('activityId')!;

  return cs.getActivity(id, activityId).pipe(
    mergeMap(activity => {
      if (activity) {
        return of(activity);
      } else {
        // id not found
        router.navigate(['/customers/' + id + '/edit']);
        return EMPTY;
      }
    })
  );
};
