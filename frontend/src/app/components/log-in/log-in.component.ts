import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';

import { SocialAuthService } from 'angularx-social-login';
import { SocialUser } from 'angularx-social-login';
import { GoogleLoginProvider } from 'angularx-social-login';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css'],
})
export class LogInComponent implements OnInit {
  user: SocialUser;
  constructor(private authService: SocialAuthService) {}

  @Output() loggedIn = new EventEmitter<boolean>();
  didLogIn = false;

  ngOnInit() {
    this.authService.authState.subscribe((user) => {
      this.user = user;
    });
  }

  signInWithGoogle(): void {
    this.authService.signIn(GoogleLoginProvider.PROVIDER_ID).then((user) => {
      console.log(user);
      this.loggedIn.emit(true);
      this.didLogIn = true;
    });
  }

  signOut(): void {
    this.authService.signOut().then(() => {
      // console.log(user);
      this.loggedIn.emit(false);
      this.didLogIn = false;
    });
  }
}
