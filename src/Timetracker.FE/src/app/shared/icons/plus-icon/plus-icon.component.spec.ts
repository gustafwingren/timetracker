import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlusIconComponent } from './plus-icon.component';

describe('PlusIconComponent', () => {
  let component: PlusIconComponent;
  let fixture: ComponentFixture<PlusIconComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [PlusIconComponent]
    });
    fixture = TestBed.createComponent(PlusIconComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
