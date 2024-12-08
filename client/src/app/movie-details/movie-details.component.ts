import { Component, inject, OnInit } from '@angular/core';
import { MoviesService } from '../_services/movies.service';
import { ActivatedRoute } from '@angular/router';
import { Movie } from '../_types/Movie';

@Component({
  selector: 'app-movie-details',
  imports: [],
  templateUrl: './movie-details.component.html',
  styleUrl: './movie-details.component.css',
})
export class MovieDetailsComponent implements OnInit {
  private movieService = inject(MoviesService);
  private route = inject(ActivatedRoute);
  movie?: Movie;

  ngOnInit(): void {
    this.loadMovie();
  }

  loadMovie() {
    const id = this.route.snapshot.paramMap.get('id');

    if (!id) return;

    this.movieService.getMovieDetails(id).subscribe({
      next: (movie) => (this.movie = movie),
    });
  }

  markMovieAsViewed(id: number) {
    this.movieService.markMovieAsViewed(id).subscribe({
      next: (_) => this.loadMovie(),
    });
  }
}
