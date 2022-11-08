import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PubDataService } from 'src/app/core/services/pub-data-service';

import { NewReviewComponent, NewReviewComponentDialogData } from './new-review.component';

describe('NewReviewComponent', () => {
  let component: NewReviewComponent;
  let fixture: ComponentFixture<NewReviewComponent>;
  let pubDataService: PubDataService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewReviewComponent],
      imports: [HttpClientTestingModule, MatDialogModule],
      providers: [
        { provide: MatDialogRef, useValue: { close: () => { } } },
        { provide: MAT_DIALOG_DATA, useValue: new NewReviewComponentDialogData(1, 'The Devonshire Arms',) },
      ],
    })
      .compileComponents();

    fixture = TestBed.createComponent(NewReviewComponent);
    pubDataService = TestBed.inject(PubDataService);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  describe('saveReview', () => {
    it('should save if form is valid', async () => {
      spyOn(pubDataService, 'savetPubReview').and.resolveTo();
      component.form.patchValue({
        id: 1,
        pubId: 1,
        date: new Date(),
        excerpt: "I am a review.",
        starsBeer: 1,
        starsAtmosphere: 2,
        starsAmenities: 3,
        starsValue: 4,
      });
      await component.saveReview(component.form);
      expect(pubDataService.savetPubReview).toHaveBeenCalled();
    });

    it('should not save if form is invalid', async () => {
      spyOn(pubDataService, 'savetPubReview').and.resolveTo();
      await component.saveReview(component.form);
      expect(pubDataService.savetPubReview).not.toHaveBeenCalled();
    });
  });
});
