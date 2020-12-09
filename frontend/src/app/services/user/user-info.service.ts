import { Injectable } from '@angular/core';

interface ISession {
  session: Object;
}

@Injectable({
  providedIn: 'root',
})
export class UserInfoService {
  constructor() {}

  set SessionId(id: string) {
    sessionStorage.setItem('session_id', id);
  }
  get SessionId(): string {
    return sessionStorage.getItem('session_id');
  }
}
