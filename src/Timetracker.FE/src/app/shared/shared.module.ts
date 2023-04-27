import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { LinkComponent } from './link/link.component';
import { AuthLinkComponent } from './auth-link/auth-link.component';
import { InputComponent } from './input/input.component';
import { FormsModule } from '@angular/forms';
import { SpinnerIconComponent } from './spinner-icon/spinner-icon.component';
import { ButtonComponent } from './button/button.component';
import { FormFieldComponent } from './form-field/form-field.component';
import { ErrorComponent } from './error/error.component';
import { LabelComponent } from './label/label.component';
import { IconsModule } from './icons/icons.module';
import { SideMenuComponent } from './side-menu/side-menu.component';

@NgModule({
  declarations: [
    HeaderComponent,
    LinkComponent,
    AuthLinkComponent,
    InputComponent,
    SpinnerIconComponent,
    ButtonComponent,
    FormFieldComponent,
    ErrorComponent,
    LabelComponent,
    SideMenuComponent,
  ],
  imports: [
    FormsModule,
    CommonModule,
    RouterLink,
    IconsModule,
    RouterLinkActive,
  ],
  exports: [
    HeaderComponent,
    InputComponent,
    SpinnerIconComponent,
    ButtonComponent,
    FormFieldComponent,
    ErrorComponent,
    LabelComponent,
    SideMenuComponent,
  ],
})
export class SharedModule {}
