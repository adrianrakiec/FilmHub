import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MoviesService } from '../_services/movies.service';
import { MovieCardComponent } from '../movie-card/movie-card.component';

@Component({
  selector: 'app-movies-list',
  imports: [MovieCardComponent],
  templateUrl: './movies-list.component.html',
  styleUrl: './movies-list.component.css',
})
export class MoviesListComponent implements OnInit {
  private router = inject(Router);
  movieService = inject(MoviesService);

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
