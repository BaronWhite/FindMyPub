import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { SearchBoxComponent } from './search-box.component';


describe('SearchBoxComponent', () => {
  let component: SearchBoxComponent;
  let fixture: ComponentFixture<SearchBoxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SearchBoxComponent],
      imports: [FormsModule, MatInputModule, MatFormFieldModule, ReactiveFormsModule, MatButtonModule],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  describe('clearSearch', () => {
    beforeEach(() => {
      component.searchControl = new FormControl("value");
      spyOn(component.clear, 'emit');
    });

    it('should clear form', () => {
      component.clearSearch();

      expect(component.searchControl.value).toBeNull();
    });

    it('should emit event', () => {
      component.clearSearch();

      expect(component.clear.emit).toHaveBeenCalled();
    });
  });
});
