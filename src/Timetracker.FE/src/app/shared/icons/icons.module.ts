import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerIconComponent } from './customer-icon/customer-icon.component';
import { ProfileIconComponent } from './profile-icon/profile-icon.component';

@NgModule({
  declarations: [CustomerIconComponent, ProfileIconComponent],
  exports: [CustomerIconComponent, ProfileIconComponent],
  imports: [CommonModule],
})
export class IconsModule {}
