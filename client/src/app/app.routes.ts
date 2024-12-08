import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MovieDetailsComponent } from './movie-details/movie-details.component';
import { AddMovieFormComponent } from './add-movie-form/add-movie-form.component';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'movie-details/:id',
    component: MovieDetailsComponent,
  },
  {
    path: 'add-movie',
    component: AddMovieFormComponent,
  },
  {
    path: '**',
    component: HomeComponent,
    pathMatch: 'full',
  },
];
