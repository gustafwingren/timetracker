import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrackComponent } from './pages/track/track.component';
import { TrackitemComponent } from './components/trackitem/trackitem.component';

@NgModule({
  declarations: [TrackComponent, TrackitemComponent],
  imports: [CommonModule],
})
export class TrackModule {}
