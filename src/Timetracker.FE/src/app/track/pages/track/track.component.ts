import { Component } from '@angular/core';
import { TrackitemComponent } from '../../components/trackitem/trackitem.component';

@Component({
  selector: 'app-track',
  templateUrl: './track.component.html',
  styleUrls: ['./track.component.scss'],
  standalone: true,
  imports: [TrackitemComponent],
})
export class TrackComponent {}
