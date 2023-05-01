import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerIconComponent } from './customer-icon/customer-icon.component';
import { ProfileIconComponent } from './profile-icon/profile-icon.component';
import { LogoutIconComponent } from './logout-icon/logout-icon.component';

@NgModule({
  declarations: [
    CustomerIconComponent,
    ProfileIconComponent,
    LogoutIconComponent,
  ],
  exports: [CustomerIconComponent, ProfileIconComponent, LogoutIconComponent],
  imports: [CommonModule],
})
export class IconsModule {}
