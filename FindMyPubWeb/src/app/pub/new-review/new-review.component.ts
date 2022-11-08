import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IPubReview } from 'src/app/core/models/pub-review';
import { PubDataService } from 'src/app/core/services/pub-data-service';

@Component({
  selector: 'app-new-review',
  templateUrl: './new-review.component.html',
  styleUrls: ['./new-review.component.css']
})
export class NewReviewComponent implements OnInit {
  form: FormGroup;
  readonly ratingMin = 1;
  readonly ratingMax = 5;
  readonly ratingStep = 0.5;
  private readonly ratingsValidator = [Validators.min(this.ratingMin), Validators.max(this.ratingMax)];

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: NewReviewComponentDialogData,
    private dialogRef: MatDialogRef<NewReviewComponent>,
    private pubService: PubDataService,
  ) {
    let fb = new FormBuilder();
    this.form = fb.nonNullable.group({
      id: new FormControl<number>(0),
      pubId: new FormControl<number>(data.pubId),
      date: new FormControl<Date>(new Date()),
      excerpt: new FormControl('', Validators.compose([Validators.required, Validators.minLength(10)])),
      starsBeer: new FormControl<number>(0, this.ratingsValidator),
      starsAtmosphere: new FormControl<number>(0, this.ratingsValidator),
      starsAmenities: new FormControl<number>(0, this.ratingsValidator),
      starsValue: new FormControl<number>(0, this.ratingsValidator),
    });
  }

  ngOnInit(): void {
  }

  async saveReview(form: FormGroup): Promise<void> {
    if (form?.valid) {
      try {
        let review: IPubReview = form.value;
        await this.pubService.savetPubReview(review);
        this.dialogRef.close(true);
      } catch {
        // TODO: notifications....
      }
    }
  }
}

export class NewReviewComponentDialogData {
  constructor(
    public pubId: number,
    public name: string,
  ) { }
}
