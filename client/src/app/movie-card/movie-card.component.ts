import { Component, inject, input } from '@angular/core';
import { Router } from '@angular/router';
import { Movie } from '../_types/Movie';
import { MoviesService } from '../_services/movies.service';

@Component({
  selector: 'app-movie-card',
  imports: [],
  templateUrl: './movie-card.component.html',
  styleUrl: './movie-card.component.css',
})
export class MovieCardComponent {
  private router = inject(Router);
  private movieService = inject(MoviesService);
  movie = input.required<Movie>();

  goToDetails(id: number) {
    this.router.navigateByUrl(`/movie-details/${id}`);
  }

  deleteMovie(id: number) {
    this.movieService.deleteMovie(id);
  }
}
