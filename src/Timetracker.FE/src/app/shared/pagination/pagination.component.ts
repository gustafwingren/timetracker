import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonComponent } from '../button/button.component';

@Component({
  selector: 'app-pagination',
  standalone: true,
  imports: [CommonModule, ButtonComponent],
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.scss'],
})
export class PaginationComponent {
  @Input({ required: true }) currentPage = 1;
  @Input({ required: true }) pageSize = 1;
  @Input({ required: true }) totalCount = 0;
  @Output() previousPage: EventEmitter<void> = new EventEmitter();
  @Output() nextPage: EventEmitter<void> = new EventEmitter();
  protected readonly Math = Math;
}
