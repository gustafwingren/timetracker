import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ButtonAccentComponent } from './button-accent.component';

describe('ButtonAccentComponent', () => {
  let component: ButtonAccentComponent;
  let fixture: ComponentFixture<ButtonAccentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ButtonAccentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ButtonAccentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
