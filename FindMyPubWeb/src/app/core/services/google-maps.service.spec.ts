import { TestBed } from '@angular/core/testing';

import { GoogleMapsService } from './google-maps.service';

describe('GoogleMapsService', () => {
  let service: GoogleMapsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GoogleMapsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should encode search strings', () => {
    const expected = `${service.mapsBaseUrl}param%20with%3C%22%23%25%7C%3Echaracters`
    const actual = service.getMapsSearchUrl(["param with<\"#%|>characters"])
    expect(actual).toEqual(expected);
  });

  it('should join search strings separated by a space', () => {
    const expected = `${service.mapsBaseUrl}first%20second`
    const actual = service.getMapsSearchUrl(["first", "second"])
    expect(actual).toEqual(expected);
  });
});
