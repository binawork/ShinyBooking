import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {RoomService} from '../room.service';
import {RoomForDetails} from '../../shared/room-for-details.model';
import {RoomAddress} from '../../shared/room-address.model';
import {DataStorageService} from '../../shared/data-storage.service';
import {HttpClient} from "@angular/common/http";
import {PhotosUploadService} from "./photos-upload.service";
import {Router} from "@angular/router";
import {RoomToAddDto} from "../../shared/room-to-add-dto.model";

@Component({
  selector: 'app-room-add',
  templateUrl: './room-add.component.html',
  styleUrls: ['./room-add.component.css', './styles.css']
})
export class RoomAddComponent implements OnInit {
  readonly postalCodeRegex: RegExp = /^[0-9]{2}-[0-9]{3}$/;
  readonly numberRegex: RegExp = /^[1-9]+[0-9]*$/;
  amenitiesCheckboxData: { name: string; AmenitiesForDisabledId: string; isChecked: boolean }[];
  equipmentCheckboxData: { name: string; EquipmentId: string; isChecked: boolean }[];
  activitiesCheckboxData: { name: string; ActivitiesId: string; isChecked: boolean }[];
  roomForm: FormGroup;
  addressForm: FormGroup;

  constructor(private fb: FormBuilder,
              private roomService: RoomService,
              private dataStorageService: DataStorageService,
              public photosUploadService: PhotosUploadService,
              private router: Router) {
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
    this.activitiesCheckboxData = this.roomService.getActivities().map(activity => ({
      ...activity,
      isChecked: false
    }));

    this.addressForm = this.fb.group({
      apartmentNumber: [44, [Validators.required, Validators.pattern, Validators.min(1)]],
      buildingNumber: [3, [Validators.required, Validators.pattern, Validators.min(1)]],
      city: ['Warsaw', [Validators.required]],
      country: ['Poland', [Validators.required]],
      postalCode: [89530, [
        Validators.required,
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
      activities: [this.activitiesCheckboxData],
      photos: []
    });

    this.roomForm.valueChanges.subscribe(console.log);
  }

  // todo nagłówek dla amenities i eq i zrozdzielenie sekcji
  onSubmit() {
    console.log('Form submitted');
    // filter amenities and equipment, so there will be only checked ones
    this.roomForm.value.amenities = this.roomForm.value.amenities.filter(amenity => amenity.isChecked === true);
    this.roomForm.value.equipment = this.roomForm.value.equipment.filter(equipment => equipment.isChecked === true);
    // remove field "isChecked"
    this.roomForm.value.amenities.map(amenity => delete amenity.isChecked);
    this.roomForm.value.equipment.map(equipment => delete equipment.isChecked);
    let submittedAddressFormValue = this.addressForm.value;
    const address = new RoomAddress(submittedAddressFormValue.buildingNumber,
      submittedAddressFormValue.city,
      submittedAddressFormValue.country,
      submittedAddressFormValue.postalCode,
      submittedAddressFormValue.apartmentNumber,
      submittedAddressFormValue.street,
    );
    let submittedRoomFormValue = this.roomForm.value;

    let newRoom = new RoomToAddDto(
      submittedRoomFormValue.id,
      submittedRoomFormValue.name,
      submittedRoomFormValue.description,
      submittedRoomFormValue.roomArrangementsCapabilitiesDescription,
      submittedRoomFormValue.price,
      submittedRoomFormValue.area,
      submittedRoomFormValue.capacity,
      submittedRoomFormValue.parkingSpace,
      this.photosUploadService.generatePhotosAsObjects(),
      submittedRoomFormValue.equipment,
      submittedRoomFormValue.amenities,
      address,
      submittedRoomFormValue.activities,
      JSON.parse(localStorage.getItem('userData'))._token
    );
    this.photosUploadService.clearAddedPhotos();
    console.log('New room:');
    console.log(newRoom);

    this.dataStorageService.storeRoom(newRoom);
    // when successfully added redirect to /rooms
    this.router.navigate(['rooms']);
    this.resetForm();
  }

  resetForm() {
    this.roomForm.value.amenities = this.amenitiesCheckboxData.slice();
    this.roomForm.value.equipment = this.equipmentCheckboxData.slice();
  }

}
