import { TestBed } from '@angular/core/testing';
import { activityDetailResolver } from './activity-detail.resolver';

describe('ActivityDetailResolver', () => {
  let resolver: activityDetailResolver;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    resolver = TestBed.inject(activityDetailResolver);
  });

  it('should be created', () => {
    expect(resolver).toBeTruthy();
  });
});
