import {Component, OnInit} from '@angular/core';
import {FormGroup, FormControl, Validators, FormBuilder} from '@angular/forms';

@Component({
  selector: 'app-room-add',
  templateUrl: './room-add.component.html',
  styleUrls: ['./room-add.component.css']
})
export class RoomAddComponent implements OnInit {

  roomForm: FormGroup;

  constructor(private fb: FormBuilder) {
  }

  ngOnInit(): void {
    this.roomForm = this.fb.group({
      id: ['id123', Validators.required],
      area: [44, [Validators.required, Validators.pattern(/^[1-9]+[0-9]*/)]],
      name: ['Test', Validators.required],
      description: ['Test description', Validators.required],
      capacity: [5, [Validators.required, Validators.pattern(/^[1-9]+[0-9]*/)]],
      parkingSpace: [false],
      roomArrangementsCapabilitiesDescription: [null, Validators.required],
      price: [null, [Validators.required, Validators.pattern(/^[1-9]+[0-9]*/)]],
    });


    this.roomForm.valueChanges.subscribe(console.log);
  }

  onSubmit() {
    console.log('Form submitted');
    console.log(this.roomForm);
  }
}
