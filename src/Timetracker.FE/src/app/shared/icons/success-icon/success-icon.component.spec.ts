import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuccessIconComponent } from './success-icon.component';

describe('SuccessIconComponent', () => {
  let component: SuccessIconComponent;
  let fixture: ComponentFixture<SuccessIconComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [SuccessIconComponent]
    });
    fixture = TestBed.createComponent(SuccessIconComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
