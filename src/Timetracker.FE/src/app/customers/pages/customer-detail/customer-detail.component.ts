import { Component, OnInit } from '@angular/core';
import { CustomerDto } from '../../models/customer-dto';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.scss'],
})
export class CustomerDetailComponent implements OnInit {
  customer!: CustomerDto;

  constructor(private route: ActivatedRoute) {}
  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.customer = data['customer'];
    });
  }
}
