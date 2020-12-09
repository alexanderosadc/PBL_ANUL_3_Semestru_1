import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CreateMeetingComponent } from './components/create-meeting/create-meeting.component';
import { MapComponent } from './components/map/map.component';
import { HomeComponent } from './components/home/home.component';
import { LogInComponent } from './components/log-in/log-in.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'log-in', component: LogInComponent },
  { path: 'map', component: MapComponent },
  { path: 'create', component: CreateMeetingComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
