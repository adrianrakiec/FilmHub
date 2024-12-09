import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MoviesService } from '../_services/movies.service';
import { MovieCardComponent } from '../movie-card/movie-card.component';
import { FilterOption, FilterStatus } from '../_types/FilterStatus';

@Component({
  selector: 'app-movies-list',
  imports: [MovieCardComponent, FormsModule],
  templateUrl: './movies-list.component.html',
  styleUrl: './movies-list.component.css',
})
export class MoviesListComponent implements OnInit {
  private router = inject(Router);
  movieService = inject(MoviesService);
  FilterOption = FilterOption;
  selectedOption: FilterStatus = FilterOption.All;

  ngOnInit(): void {
    if (this.movieService.movies().length === 0) this.getMovies();
  }

  getMovies(): void {
    this.movieService.getMovies();
  }

  goToAddMovie() {
    this.router.navigateByUrl(`/add-movie`);
  }
}
