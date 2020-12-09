import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserInfoService } from './services/user/user-info.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'frontend';
  constructor(authService: UserInfoService, router: Router) {
    if (authService.SessionId === 'null' || authService.SessionId === null) {
      router.navigate(['log-in']);
    }
  }
}
