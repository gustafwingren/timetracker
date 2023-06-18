import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchIconComponent } from '../icons/search-icon/search-icon.component';

@Component({
  selector: 'app-search-input',
  standalone: true,
  imports: [CommonModule, SearchIconComponent],
  templateUrl: './search-input.component.html',
  styleUrls: ['./search-input.component.scss'],
})
export class SearchInputComponent {
  @Output() search: EventEmitter<string> = new EventEmitter<string>();

  searchChange($event: Event) {
    const searchString = ($event.target as HTMLInputElement).value;
    this.search.emit(searchString);
  }
}
