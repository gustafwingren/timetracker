import { Component, OnInit } from '@angular/core';
import { ActivityDto } from '../../models/activity-dto';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-activity-detail',
  templateUrl: './activity-detail.component.html',
  styleUrls: ['./activity-detail.component.scss'],
})
export class ActivityDetailComponent implements OnInit {
  activity!: ActivityDto;
  customerId!: string;

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.customerId = params.get('id')!;
    });
    this.route.data.subscribe(data => {
      this.activity = data['activity'];
    });
  }
}
