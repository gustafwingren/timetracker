import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { RouterLink } from '@angular/router';
import { LinkComponent } from './link/link.component';
import { AuthLinkComponent } from './auth-link/auth-link.component';

@NgModule({
  declarations: [HeaderComponent, LinkComponent, AuthLinkComponent],
  imports: [CommonModule, RouterLink],
  exports: [HeaderComponent],
})
export class SharedModule {}
