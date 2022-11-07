import { HttpClientTestingModule } from '@angular/common/http/testing';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/compiler';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatTableModule } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { StarRatingModule } from 'angular-star-rating';
import { IPub } from 'src/app/core/models/pub';
import { IPubSummary } from 'src/app/core/models/pub-summary';
import { PubDataService } from 'src/app/core/services/pub-data-service';
import { SharedModule } from 'src/app/shared/shared.module';

import { PubListComponent } from './pub-list.component';

describe('PubListComponent', () => {
  let component: PubListComponent;
  let fixture: ComponentFixture<PubListComponent>;
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
  const pubs: IPubSummary[] = [
    pub,
  ];

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PubListComponent],
      imports: [
        BrowserAnimationsModule,
        HttpClientTestingModule,
        MatTableModule,
        MatPaginatorModule,
        MatTooltipModule,
        SharedModule,
        StarRatingModule,
        MatProgressBarModule,
      ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
      .compileComponents();

    fixture = TestBed.createComponent(PubListComponent);
    pubDataService = TestBed.inject(PubDataService);
    component = fixture.componentInstance;

    spyOn(pubDataService, 'getPubsSummary').and.resolveTo(pubs);

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  describe('loadPubs', () => {
    it('should get pubs from service', async () => {
      await component.loadPubs()
      expect(pubDataService.getPubsSummary).toHaveBeenCalled();
    });

    it('should assign pubs to  dataset', async () => {
      await component.loadPubs()
      expect(component.pubDataSource.data).toEqual(pubs);
    });

    it('should not error if service call fails', async () => {
      pubDataService.getPubsSummary = jasmine.createSpy().and.rejectWith();
      await component.loadPubs()
      expect(component.pubDataSource.data).toEqual(pubs);
    });
  });


  describe('filter', () => {
    it('should filter data', async () => {
      component.searchControl.setValue('I am not in the list');
      expect(component.pubDataSource.filteredData.length).toBe(0);
    });
  });
});
