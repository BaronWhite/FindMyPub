import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { IPub } from 'src/app/core/models/pub';
import { PubDataService } from 'src/app/core/services/pub-data-service';

import { PubComponent, PubComponentDialogData } from './pub.component';

describe('PubComponent', () => {
  let component: PubComponent;
  let fixture: ComponentFixture<PubComponent>;
  let pubDataService: PubDataService;
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
});
