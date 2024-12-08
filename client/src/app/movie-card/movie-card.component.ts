import { Component, inject, input } from '@angular/core';
import { Router } from '@angular/router';
import { Movie } from '../_types/Movie';
import { MoviesService } from '../_services/movies.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-movie-card',
  imports: [FormsModule],
  templateUrl: './movie-card.component.html',
  styleUrl: './movie-card.component.css',
})
export class MovieCardComponent {
  private router = inject(Router);
  private movieService = inject(MoviesService);
  movie = input.required<Movie>();
  isNoteVisible: boolean = false;
  isEditMode: boolean = false;

  goToDetails(id: number) {
    this.router.navigateByUrl(`/movie-details/${id}`);
  }

  deleteMovie(id: number) {
    this.movieService.deleteMovie(id);
  }

  toggleClass() {
    this.isNoteVisible = !this.isNoteVisible;
    this.isEditMode = false;
  }

  toggleEditMode(): void {
    this.isEditMode = !this.isEditMode;
    if (!this.isEditMode) {
      this.movieService.editNote(this.movie().userNotes, this.movie().id);
      this.toggleClass();
    }
  }
}
