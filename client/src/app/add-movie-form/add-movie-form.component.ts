import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-movie-form',
  imports: [ReactiveFormsModule],
  templateUrl: './add-movie-form.component.html',
  styleUrl: './add-movie-form.component.css',
})
export class AddMovieFormComponent implements OnInit {
  addMovieForm: FormGroup = new FormGroup({});

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.addMovieForm = new FormGroup({
      title: new FormControl(),
      userNotes: new FormControl(),
    });
  }

  onSubmit() {
    console.log(this.addMovieForm.value);
  }
}
