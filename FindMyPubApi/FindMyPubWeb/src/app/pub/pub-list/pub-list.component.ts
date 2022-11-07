import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { IPubSummary } from 'src/app/core/models/pub-summary';
import { GoogleMapsService } from 'src/app/core/services/google-maps.service';
import { PubDataService } from 'src/app/core/services/pub-data-service';

@Component({
  selector: 'app-pub-list',
  templateUrl: './pub-list.component.html',
  styleUrls: ['./pub-list.component.scss']
})
export class PubListComponent implements OnInit, OnDestroy {
  isLoading: boolean = false;

  pubDataSource: MatTableDataSource<IPubSummary> = new MatTableDataSource();
  displayedColumns: string[] = ['thumbnail', 'name', 'address', 'phone', 'ratings'];

  searchControl = new FormControl();
  searchSubscription!: Subscription;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private pubService: PubDataService, public googleMapsService: GoogleMapsService) { }

  ngOnInit(): void {
    this.loadPubs();
    this.searchSubscription = this.searchControl.valueChanges.subscribe(filterValue => {
      this.pubDataSource.filter = filterValue?.trim().toLowerCase();
    });
  }

  ngOnDestroy(): void {
    this.searchSubscription.unsubscribe()
  }

  async loadPubs() {
    this.isLoading = true;
    try {
      let pubs = await this.pubService.getPubsSummary();
      this.pubDataSource.data = pubs;
      this.paginator.pageSize = 10;
      this.pubDataSource.paginator = this.paginator;
      this.pubDataSource.filterPredicate = this.filterPredicate;
    } catch (error) {
      // TODO: Implement notifications
    }
    finally { this.isLoading = false; }
  }

  private filterPredicate = (data: IPubSummary, filter: string): boolean => {
    let match = data.name.toLowerCase().includes(filter) || data.location.address.toLowerCase().includes(filter);
    return match;
  };
}
