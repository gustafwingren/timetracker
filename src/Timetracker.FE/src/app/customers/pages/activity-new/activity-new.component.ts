import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-activity-new',
  templateUrl: './activity-new.component.html',
  styleUrls: ['./activity-new.component.scss'],
  standalone: true,
  imports: [FormsModule],
})
export class ActivityNewComponent implements OnInit {
  ngOnInit(): void {
    console.log('ActivityNewComponent ngOnInit');
  }
}
