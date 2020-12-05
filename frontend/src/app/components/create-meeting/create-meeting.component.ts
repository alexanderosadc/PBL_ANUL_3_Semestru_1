import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Validators } from '@angular/forms';

interface Room {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-create-meeting',
  templateUrl: './create-meeting.component.html',
  styleUrls: ['./create-meeting.component.css'],
})
export class CreateMeetingComponent implements OnInit {
  rooms: Room[] = [
    { value: 'steak-0', viewValue: 'Steak' },
    { value: 'pizza-1', viewValue: 'Pizza' },
    { value: 'tacos-2', viewValue: 'Tacos' },
  ];

  public profileForm: FormGroup;
  constructor(private fb: FormBuilder) {
    this.profileForm = this.fb.group({
      meetingStartDate: ['', Validators.required], // sa fie date timepicker
      meetingEndDate: ['', Validators.required],
      meetingStartTime: ['', Validators.required],
      meetingEndTime: ['', Validators.required],
      meetingRoom: ['', Validators.required],
    });
  }

  onSubmit() {
    console.log(this.profileForm.value);
  }

  ngOnInit(): void {
    console.log('create called');
  }
}
