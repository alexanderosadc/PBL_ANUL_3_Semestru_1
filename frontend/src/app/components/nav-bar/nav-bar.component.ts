import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css'],
})
export class NavBarComponent implements OnInit {
  public LoggedIn = false;

  constructor() {}

  ngOnInit(): void {}

  onLogIn(auth: boolean) {
    console.log('logged in');
    this.LoggedIn = auth;
  }
}
