import { AddMovie } from './../_types/AddMovie';
import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { Movie } from '../_types/Movie';
import { environment } from '../../environments/environment.development';
import { SearchResponse } from '../_types/SearchResponse';

@Injectable({
  providedIn: 'root',
})
export class MoviesService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = environment.apiUrl;
  movies = signal<Movie[]>([]);

  getMovies() {
    return this.http.get<Movie[]>(this.baseUrl + 'movies').subscribe({
      next: (movies) => this.movies.set(movies),
    });
  }

  searchMovies(query: string) {
    return this.http.get<SearchResponse>(
      this.baseUrl + `movies/search?query=${query}&page=1`
    );
  }

  getMovieDetails(id: string) {
    return this.http.get<Movie>(this.baseUrl + `movies/${id}`);
  }

  markMovieAsViewed(id: number) {
    return this.http.patch(this.baseUrl + `movies/edit-viewed/${id}`, null);
  }

  deleteMovie(id: number) {
    return this.http.delete(this.baseUrl + `movies/${id}`).subscribe({
      next: () => {
        const updatedMovies = this.movies().filter((movie) => movie.id !== id);
        this.movies.set(updatedMovies);
      },
    });
  }

  createMovie(body: AddMovie) {
    return this.http.post<Movie>(this.baseUrl + 'movies', body).subscribe({
      next: (res) => {
        const updatedMovies = [...this.movies(), res];
        this.movies.set(updatedMovies);
      },
    });
  }

  editNote(note: string, id: number) {
    return this.http
      .patch(this.baseUrl + `movies/note/${id}?note=${note}`, null)
      .subscribe();
  }
}
