import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { firstValueFrom } from 'rxjs';
import { IPub } from 'src/app/core/models/pub';
import { PubDataService } from 'src/app/core/services/pub-data-service';
import { NewReviewComponent, NewReviewComponentDialogData } from '../new-review/new-review.component';

@Component({
  selector: 'app-pub',
  templateUrl: './pub.component.html',
  styleUrls: ['./pub.component.scss']
})

export class PubComponent implements OnInit {
  isLoading: boolean = false;
  pub!: IPub;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: PubComponentDialogData,
    private dialogRef: MatDialogRef<PubComponent>,
    private pubService: PubDataService,
    private dialog: MatDialog,
  ) { }

  ngOnInit(): void {
    this.loadPub(this.data.pubId);
  }

  async loadPub(pubId: number) {
    this.isLoading = true;
    try {
      this.pub = await this.pubService.getPub(pubId);
    } catch (error) {
      // TODO: Implement notifications
    }
    finally { this.isLoading = false; }
  }

  async openNewReviewDialog(pub: IPub) {
    let dialogRef = this.dialog.open(NewReviewComponent, {
      data: new NewReviewComponentDialogData(pub.id, pub.name)
    });
    let hasChanges = await firstValueFrom(dialogRef.afterClosed());
    if (hasChanges) {
      this.loadPub(this.data.pubId);
    }
  }
}

export class PubComponentDialogData {
  constructor(
    public pubId: number,
    public name: string,
    public thumbnail: string,
  ) { }
}
