import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { TableHeader } from './tableHeader';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss'],
})
export class TableComponent {
  @Input({ required: true }) loading = false;
  @Input({ required: true }) headers: TableHeader[] = [];
  @Input({ required: true }) objects: any[] = [];
}
