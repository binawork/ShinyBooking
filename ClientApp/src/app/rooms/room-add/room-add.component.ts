import {Component, OnInit} from '@angular/core';
import {FormGroup, FormControl, Validators, FormBuilder} from '@angular/forms';

@Component({
  selector: 'app-room-add',
  templateUrl: './room-add.component.html',
  styleUrls: ['./room-add.component.css']
})
export class RoomAddComponent implements OnInit {
  readonly postalCodeRegex: RegExp = /^[0-9]{2}-[0-9]{3}$/;
  readonly numberRegex: RegExp = /^[1-9]+[0-9]*$/;


  roomForm: FormGroup;
  addressForm: FormGroup;

  constructor(private fb: FormBuilder,
              ) {
  }

  ngOnInit(): void {
    this.addressForm = this.fb.group({
      apartmentNumber: [44, [Validators.pattern, Validators.min(1)]],
      buildingNumber: [3, [Validators.required, Validators.pattern, Validators.min(1)]],
      city: ['Warsaw', [Validators.required]],
      country: ['Poland', [Validators.required]],
      postalCode: ['89-530', [
        Validators.required,
        Validators.pattern(this.postalCodeRegex)
      ]],
      street: ['Bar'],
    });

    this.roomForm = this.fb.group({
      id: ['id123', Validators.required],
      area: [44, [Validators.required, Validators.pattern(this.numberRegex)]],
      name: ['Test', Validators.required],
      description: ['Test description', Validators.required],
      capacity: [5, [Validators.required, Validators.pattern(this.numberRegex)]],
      parkingSpace: [false],
      roomArrangementsCapabilitiesDescription: ['Sample', Validators.required],
      price: [80, [Validators.required, Validators.pattern(this.numberRegex)]],
      roomAddress: this.addressForm,
    });


    this.roomForm.valueChanges.subscribe(console.log);
  }

  onSubmit() {
    console.log('Form submitted');
    console.log(this.roomForm);
    console.dir(this.roomForm.value);
  }
}
