import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-search-box',
  templateUrl: './search-box.component.html',
  styleUrls: ['./search-box.component.scss']
})
export class SearchBoxComponent implements OnInit {
  @Input() searchControl: FormControl = new FormControl();
  @Input() placeholder: string = "";
  @Input() disabled: boolean = false;
  @Output() searchChange: EventEmitter<any> = new EventEmitter();
  @Output() clear: EventEmitter<void> = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  clearSearch(): void {
    this.searchControl.reset();
    this.clear.emit();
  }
}
