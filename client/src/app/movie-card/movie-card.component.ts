import { Component, inject, input } from '@angular/core';
import { Router } from '@angular/router';
import { Movie } from '../_types/Movie';

@Component({
  selector: 'app-movie-card',
  imports: [],
  templateUrl: './movie-card.component.html',
  styleUrl: './movie-card.component.css',
})
export class MovieCardComponent {
  movie = input.required<Movie>();
  router = inject(Router);

  goToDetails(id: number) {
    this.router.navigateByUrl(`/movie-details/${id}`);
  }
}
