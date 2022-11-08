import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialog, MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { of } from 'rxjs';
import { IPub } from 'src/app/core/models/pub';
import { PubDataService } from 'src/app/core/services/pub-data-service';

import { PubComponent, PubComponentDialogData } from './pub.component';

describe('PubComponent', () => {
  let component: PubComponent;
  let fixture: ComponentFixture<PubComponent>;
  let pubDataService: PubDataService;
  let dialog: MatDialog;

  const pub: IPub = {
    id: 1,
    name: "Queens Head",
    category: "Review",
    thumbnail: "http://example.com",
    location: { address: "", latitude: 0, longitude: 0 },
    url: "",
    phone: "",
    twitter: "",
    tags: [],
    reviews: [],
    starsBeer: 3,
    starsAtmosphere: 3,
    starsAmenities: 3,
    starsValue: 3,
  };

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PubComponent],
      imports: [
        HttpClientTestingModule,
        MatProgressBarModule,
        MatDialogModule,
      ],
      providers: [
        { provide: MatDialogRef, useValue: { close: () => { } } },
        { provide: MAT_DIALOG_DATA, useValue: new PubComponentDialogData(pub.id, pub.name, pub.thumbnail) },
      ],
    })
      .compileComponents();

    fixture = TestBed.createComponent(PubComponent);
    component = fixture.componentInstance;
    pubDataService = TestBed.inject(PubDataService);
    dialog = TestBed.inject(MatDialog);

    spyOn(pubDataService, 'getPub').and.resolveTo(pub);

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });


  describe('loadPubs', () => {
    it('should get pubs from service', async () => {
      await component.loadPub(pub.id)
      expect(pubDataService.getPub).toHaveBeenCalledWith(pub.id);
    });

    it('should assign pubs to  dataset', async () => {
      await component.loadPub(pub.id)
      expect(component.pub).toEqual(pub);
    });

    it('should not error if service call fails', async () => {
      pubDataService.getPub = jasmine.createSpy().and.rejectWith();
      await component.loadPub(pub.id)
      expect(component).toBeTruthy();
    });
  });


  describe('openNewReviewDialog', () => {
    const dialogRefConfirmSpy = jasmine.createSpyObj({ afterClosed: of(true), close: null });

    it('should open dialog', async () => {
      spyOn(dialog, 'open').and.returnValue(dialogRefConfirmSpy);
      await component.openNewReviewDialog(pub);
      expect(dialog.open).toHaveBeenCalled();
    });

    it('should reload pub if changes', async () => {
      spyOn(dialog, 'open').and.returnValue(dialogRefConfirmSpy);
      await component.openNewReviewDialog(pub);
      expect(pubDataService.getPub).toHaveBeenCalledWith(pub.id);
    });
  });
});
