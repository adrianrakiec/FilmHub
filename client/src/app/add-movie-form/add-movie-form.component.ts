import { Component, inject, OnInit, signal } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { catchError, debounceTime, of, switchMap } from 'rxjs';
import { MoviesService } from '../_services/movies.service';
import { SearchResponse } from '../_types/SearchResponse';
import { SearchResultMovieComponent } from '../search-result-movie/search-result-movie.component';
import { AddMovie } from '../_types/AddMovie';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-movie-form',
  imports: [ReactiveFormsModule, SearchResultMovieComponent],
  templateUrl: './add-movie-form.component.html',
  styleUrl: './add-movie-form.component.css',
})
export class AddMovieFormComponent implements OnInit {
  private movieService = inject(MoviesService);
  private router = inject(Router);
  addMovieForm: FormGroup = new FormGroup({});
  searchResults = signal<SearchResponse | null>(null);
  errorMessage = signal<string | null>(null);
  isManuallySettingTitle = false;
  body: AddMovie = { title: '' };

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.addMovieForm = new FormGroup({
      title: new FormControl(),
      userNotes: new FormControl(),
    });

    this.addMovieForm
      .get('title')
      ?.valueChanges.pipe(
        debounceTime(500),
        switchMap((searchTerm: string) => {
          if (this.isManuallySettingTitle) {
            this.isManuallySettingTitle = false;
            return of(null);
          }
          return searchTerm.trim()
            ? this.movieService.searchMovies(searchTerm).pipe(
                catchError((err) => {
                  this.errorMessage.set('Error fetching movies.');
                  return of(null);
                })
              )
            : of(null);
        })
      )
      .subscribe({
        next: (response) => {
          this.searchResults.set(response);
          this.errorMessage.set(
            response && response.search.length === 0
              ? 'No results found.'
              : null
          );
        },
      });
  }

  fillTitle(title: string): void {
    this.addMovieForm.get('title')?.setValue(title);
    this.searchResults.set(null);
    this.isManuallySettingTitle = true;
  }

  onSubmit() {
    this.body.title = this.addMovieForm.get('title')?.value;
    this.body.userNotes = this.addMovieForm.get('userNotes')?.value;
    this.movieService.createMovie(this.body);
    this.router.navigateByUrl('/');
  }
}
