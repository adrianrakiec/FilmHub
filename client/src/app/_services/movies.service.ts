import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Movie } from '../_types/Movie';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class MoviesService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = environment.apiUrl;

  getMovies() {
    return this.http.get<Movie[]>(this.baseUrl + 'movies');
  }

  getMovieDetails(id: string) {
    return this.http.get<Movie>(this.baseUrl + `movies/${id}`);
  }

  markMovieAsViewed(id: number) {
    return this.http.patch(this.baseUrl + `movies/edit-viewed/${id}`, null);
  }

  deleteMovie(id: number) {
    return this.http.delete(this.baseUrl + `movies/${id}`);
  }
}
