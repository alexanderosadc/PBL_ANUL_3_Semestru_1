import { Component, OnInit } from '@angular/core';
// import { ApiService } from './../../services/api.service';
import { Subscription } from 'rxjs';

interface Event {
  name: string;
  start: string;
  end: string;
  cab: string;
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  private subs: Subscription;
  constructor() {}
  // constructor(private service: ApiService) {}
  events: Event[] = [
    { name: 'alll cmdocm', start: 'am', end: 'pm', cab: 'pizza' },
    { name: 'neel cmdocm', start: 'am', end: 'pm', cab: 'steak' },
    { name: 'alll cmdocm', start: 'am', end: 'pm', cab: 'pizza' },
    // { name: 'neel cmdocm', start: 'am', end: 'pm', cab: 'steak' },
  ];

  ngOnInit(): void {}

  // ngOnInit(): void {
  //   this.subs = this.service
  //     .getEvents('something')
  //     .subscribe((events) => {
  //       console.log(events);
  //     })
  // }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}
