import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {RoomService} from '../room.service';

@Component({
  selector: 'app-room-add',
  templateUrl: './room-add.component.html',
  styleUrls: ['./room-add.component.css']
})
export class RoomAddComponent implements OnInit {
  readonly postalCodeRegex: RegExp = /^[0-9]{2}-[0-9]{3}$/;
  readonly numberRegex: RegExp = /^[1-9]+[0-9]*$/;
  amenitiesCheckboxData: { name: string; id: string; isChecked: boolean }[];
  equipmentCheckboxData: { name: string; id: string; isChecked: boolean }[];
  roomForm: FormGroup;
  addressForm: FormGroup;

  constructor(private fb: FormBuilder,
              private roomService: RoomService) {
  }

  ngOnInit(): void {
    this.amenitiesCheckboxData = this.roomService.getAmenitiesForDisabled().map(x => ({
      ...x,
      isChecked: false
    }));
    this.equipmentCheckboxData = this.roomService.getEquipment().map(equipment => ({
      ...equipment,
      isChecked: false
    }));

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
      amenities: [this.amenitiesCheckboxData],
      equipment: [this.equipmentCheckboxData],
    });


    this.roomForm.valueChanges.subscribe(console.log);
  }

  onSubmit() {
    console.log('Form submitted');
    // filter amenities and equipment, so there will be only checked ones
    this.roomForm.value.amenities = this.roomForm.value.amenities.filter(amenity => amenity.isChecked === true);
    this.roomForm.value.equipment = this.roomForm.value.equipment.filter(equipment => equipment.isChecked === true);
    // remove field "isChecked"
    this.roomForm.value.amenities.map(amenity => delete amenity.isChecked);
    this.roomForm.value.equipment.map(equipment => delete equipment.isChecked);
    console.dir(this.roomForm.value.amenities);
    console.dir(this.roomForm.value.equipment);

    this.resetForm();
  }

  resetForm() {
    this.roomForm.value.amenities = this.amenitiesCheckboxData.slice();
    this.roomForm.value.equipment = this.equipmentCheckboxData.slice();
  }
}
