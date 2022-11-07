import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { IPub } from '../models/pub';
import { IPubSummary } from '../models/pub-summary';

@Injectable({
  providedIn: 'root'
})
export class PubDataService {

  constructor(private http: HttpClient) { }

  getPubsSummary(): Promise<IPubSummary[]> {
    return firstValueFrom(this.http.get<IPubSummary[]>('/pubs/summary'));
  }

  getPub(id: number): Promise<IPub> {
    return firstValueFrom(this.http.get<IPub>(`/pubs/${id}`));
  }
}
