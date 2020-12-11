import { Component, OnInit } from '@angular/core';
import { ApiService } from './../../services/api/api.service';
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
  // constructor(private service: ApiService) {}
  public events: Event[] = [
    {
      name: 'Network programming exam',
      start: '11/01/21 11:30',
      end: '12/01/21 13:00',
      cab: 'Pizza',
    },
    {
      name: 'Frontend team Meeting',
      start: '07/12/20 11:00',
      end: '07/12/20 11:00',
      cab: 'Steak',
    },
    { name: 'Some meeting', start: 'am', end: 'pm', cab: 'Tacos' },
    { name: 'Other meeting', start: 'am', end: 'pm', cab: 'Steak' },
  ];

  ngOnInit(): void {}

  // ngOnInit(): void {
  //   this.subs = this.service
  //     .getEvents('something')
  //     .subscribe((events) => {
  //       console.log(events);
  //        this.events = events
  //     })
  // }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}
