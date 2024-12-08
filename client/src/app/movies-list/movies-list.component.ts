import { Component, inject, OnInit } from '@angular/core';
import { MoviesService } from '../_services/movies.service';
import { MovieCardComponent } from '../movie-card/movie-card.component';

@Component({
  selector: 'app-movies-list',
  imports: [MovieCardComponent],
  templateUrl: './movies-list.component.html',
  styleUrl: './movies-list.component.css',
})
export class MoviesListComponent implements OnInit {
  movieService = inject(MoviesService);

  ngOnInit(): void {
    if (this.movieService.movies().length === 0) this.getMovies();
  }

  getMovies(): void {
    this.movieService.getMovies();
  }
}
