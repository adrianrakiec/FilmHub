import { Component, inject, OnInit } from '@angular/core';
import { MoviesService } from '../_services/movies.service';
import { MovieCardComponent } from '../movie-card/movie-card.component';
import { Movie } from '../_types/Movie';

@Component({
  selector: 'app-movies-list',
  imports: [MovieCardComponent],
  templateUrl: './movies-list.component.html',
  styleUrl: './movies-list.component.css',
})
export class MoviesListComponent implements OnInit {
  private movieService = inject(MoviesService);
  movies: Movie[] = [];

  ngOnInit(): void {
    this.getMovies();
  }

  getMovies(): void {
    this.movieService.getMovies().subscribe({
      next: (data) => (this.movies = data),
    });
  }

  onDeleteMovie(id: number): void {
    this.movies = this.movies.filter((movie) => movie.id !== id);
  }
}
