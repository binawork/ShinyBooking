import {Component, OnInit} from '@angular/core';
import {FormGroup, FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-room-add',
  templateUrl: './room-add.component.html',
  styleUrls: ['./room-add.component.css']
})
export class RoomAddComponent implements OnInit {

  roomForm: FormGroup;

  constructor() {
  }

  ngOnInit(): void {
    this.roomForm = new FormGroup({
      id: new FormControl('id123', Validators.required),
      area: new FormControl('44', [Validators.required, Validators.pattern(/^[1-9]+[0-9]*/)]),
      name: new FormControl('Test', Validators.required),
      description: new FormControl('Dsadasdasds', Validators.required),
      capacity: new FormControl('5', [Validators.required, Validators.pattern(/^[1-9]+[0-9]*/)]),
    });


    this.roomForm.valueChanges.subscribe(console.log);
  }

  onSubmit() {
    console.log('Form submitted');
    console.log(this.roomForm);
  }
}
