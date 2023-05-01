import { NgModule } from '@angular/core';
import { CommonModule, NgOptimizedImage } from '@angular/common';
import { LoginRoutingModule } from './login-routing.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [LoginRoutingModule.components],
  imports: [CommonModule, NgOptimizedImage, SharedModule],
})
export class LoginModule {}
