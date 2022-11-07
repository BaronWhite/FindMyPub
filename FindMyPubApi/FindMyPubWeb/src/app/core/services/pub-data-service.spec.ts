import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { fakeAsync, TestBed } from '@angular/core/testing';
import { IPub } from '../models/pub';
import { IPubSummary } from '../models/pub-summary';

import { PubDataService } from './pub-data-service';

describe('PubDataService', () => {
  let service: PubDataService;
  let httpMock: HttpTestingController;

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

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(PubDataService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get pub summary', fakeAsync(() => {
    service.getPubsSummary().then(response => {
      expect(response).toEqual(pubs);
    });

    const req = httpMock.expectOne('/pubs/summary');
    expect(req.request.method).toEqual('GET');
    req.flush(pubs);
    httpMock.verify;
  }));

  it('should get a pub', fakeAsync(() => {
    service.getPub(pub.id).then(response => {
      expect(response).toEqual(pub);
    });

    const req = httpMock.expectOne(`/pubs/${pub.id}`);
    expect(req.request.method).toEqual('GET');
    req.flush(pub);
    httpMock.verify;
  }));
});
