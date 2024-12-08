import { Component, inject, OnInit } from '@angular/core';
import { MoviesService } from './_services/movies.service';
import { Movie } from './_types/Movie';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
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
}
