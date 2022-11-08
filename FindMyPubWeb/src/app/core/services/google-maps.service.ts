import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GoogleMapsService {
  readonly mapsBaseUrl = "https://www.google.com/maps/search/?api=1&query=";

  constructor() { }

  getMapsSearchUrl(searchStrings: string[]): string {
    let encodedPlaceName = searchStrings.map(s => encodeURIComponent(s));
    return this.mapsBaseUrl + encodedPlaceName.join("%20");
  }
}
