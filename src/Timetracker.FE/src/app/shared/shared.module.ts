import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { RouterLink } from '@angular/router';
import { LinkComponent } from './link/link.component';
import { AuthLinkComponent } from './auth-link/auth-link.component';
import { InputComponent } from './input/input.component';
import { ReactiveFormsModule } from '@angular/forms';
import { LabeledInputComponent } from './labeled-input/labeled-input.component';
import { SpinnerIconComponent } from './spinner-icon/spinner-icon.component';

@NgModule({
  declarations: [
    HeaderComponent,
    LinkComponent,
    AuthLinkComponent,
    InputComponent,
    LabeledInputComponent,
    SpinnerIconComponent,
  ],
  imports: [CommonModule, RouterLink, ReactiveFormsModule],
  exports: [
    HeaderComponent,
    InputComponent,
    LabeledInputComponent,
    SpinnerIconComponent,
  ],
})
export class SharedModule {}
