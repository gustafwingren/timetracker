import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { RouterLink } from '@angular/router';
import { LinkComponent } from './link/link.component';
import { AuthLinkComponent } from './auth-link/auth-link.component';
import { InputComponent } from './input/input.component';
import { FormsModule } from '@angular/forms';
import { LabeledInputComponent } from './labeled-input/labeled-input.component';
import { SpinnerIconComponent } from './spinner-icon/spinner-icon.component';
import { ButtonComponent } from './button/button.component';
import { ButtonPrimaryComponent } from './button-primary/button-primary.component';
import { ButtonAccentComponent } from './button-accent/button-accent.component';

@NgModule({
  declarations: [
    HeaderComponent,
    LinkComponent,
    AuthLinkComponent,
    InputComponent,
    LabeledInputComponent,
    SpinnerIconComponent,
    ButtonComponent,
    ButtonPrimaryComponent,
    ButtonAccentComponent,
  ],
  imports: [FormsModule, CommonModule, RouterLink],
  exports: [
    HeaderComponent,
    InputComponent,
    LabeledInputComponent,
    SpinnerIconComponent,
    ButtonComponent,
    ButtonPrimaryComponent,
    ButtonAccentComponent,
  ],
})
export class SharedModule {}
