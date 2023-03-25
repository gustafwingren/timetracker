import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomersComponent } from './pages/customers/customers.component';
import { CustomerService } from './services/customer.service';
import { RouterLink } from '@angular/router';
import { CustomersRoutingModule } from './customers-routing.module';
import { CustomerDetailComponent } from './pages/customer-detail/customer-detail.component';
import { CustomerNewComponent } from './pages/customer-new/customer-new.component';
import { ActivityDetailComponent } from './pages/activity-detail/activity-detail.component';
import { ActivityNewComponent } from './pages/activity-new/activity-new.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    CustomersComponent,
    CustomerDetailComponent,
    CustomerNewComponent,
    ActivityDetailComponent,
    ActivityNewComponent,
  ],
  providers: [CustomerService],
  imports: [
    CommonModule,
    RouterLink,
    CustomersRoutingModule,
    ReactiveFormsModule,
    SharedModule,
  ],
})
export class CustomersModule {}
