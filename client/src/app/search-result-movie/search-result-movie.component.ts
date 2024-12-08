import { Component, EventEmitter, input, Output } from '@angular/core';
import { Search } from '../_types/Search';

@Component({
  selector: 'app-search-result-movie',
  imports: [],
  templateUrl: './search-result-movie.component.html',
  styleUrl: './search-result-movie.component.css',
})
export class SearchResultMovieComponent {
  @Output() selectTitle = new EventEmitter<string>();

  result = input.required<Search>();

  onClick() {
    this.selectTitle.emit(this.result().title);
  }
}
