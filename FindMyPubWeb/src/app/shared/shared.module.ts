import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FaIconLibrary, FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faSearch, faTimes } from '@fortawesome/free-solid-svg-icons';
import { SearchBoxComponent } from './search-box/search-box.component';


@NgModule({
  declarations: [
    SearchBoxComponent
  ],
  exports: [
    SearchBoxComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    MatInputModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatButtonModule,
    FontAwesomeModule,
  ],
})
export class SharedModule {
  constructor(library: FaIconLibrary) {
    library.addIcons(faTimes, faSearch);
  }
}
