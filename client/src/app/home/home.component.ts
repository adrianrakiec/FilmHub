import { Component } from '@angular/core';
import { MoviesListComponent } from '../movies-list/movies-list.component';

@Component({
  selector: 'app-home',
  imports: [MoviesListComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {}
