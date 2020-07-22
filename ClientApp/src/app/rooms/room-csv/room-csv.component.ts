import {Component, ViewChild} from '@angular/core';
import {NgxCsvParser, NgxCSVParserError} from 'ngx-csv-parser';
import {RoomToAddDto} from "../../shared/room-to-add-dto.model";
import {CsvRecordModel} from "./csv-record.model";
import {Equipment} from "../equipment.model";
import {AmenityForDisabled} from "../amenity-for-disabled.model";
import {Activity} from "../activity.model";
import {Photo} from "../../shared/photo.model";
import {RoomAddress} from "../../shared/room-address.model";
import {DataStorageService} from "../../shared/data-storage.service";

@Component({
  selector: 'app-root',
  templateUrl: './room-csv.component.html',
  styleUrls: ['./room-csv.component.css', '../../styles.css']
})

export class RoomCsvComponent {

  csvRecords: CsvRecordModel[] = [];
  header = true;

  constructor(private ngxCsvParser: NgxCsvParser, private dataStorageService: DataStorageService) {
  }

  @ViewChild('fileImportInput') fileImportInput: any;

  fileChangeListener($event: any): void {

    const files = $event.srcElement.files;

    this.ngxCsvParser.parse(files[0], {header: this.header, delimiter: ';'})
      .pipe().subscribe((result: Array<any>) => {
      console.log('Result', result);
      this.csvRecords = result;
    }, (error: NgxCSVParserError) => {
      console.log('Error', error);
    });
  }

  addRooms() {
    for (let record of this.csvRecords) {
      let newRoom = new RoomToAddDto(
        record.propertyTitle,
        record.Description,
        record.RoomArrangementCapabilities,
        +record.Price,
        +record.Area,
        +record.Capacity,
        +record.ParkingSpace != 0,
        this.generatePhotoAsObject(record.Photos),
        this.addEquipment(record),
        this.addAmenities(record),
        this.generateAddress(record),
        this.addActivities(record),
        this.getToken()
      );
      this.dataStorageService.storeRoom(newRoom);
    }

    this.csvRecords = [];
  }

  addEquipment({EquipmentFax, EquipmentCoffe, EquipmentPs4, EquipmentMarshall, EquipmentKitchen}) {
    let equipment: Equipment[] = [];
    if (+EquipmentFax == 1) {
      equipment.push(new Equipment('equipment1', 'fax machine'))
    }
    if (+EquipmentCoffe == 1) {
      equipment.push(new Equipment('equipment2', 'coffee machine'))
    }
    if (+EquipmentPs4 == 1) {
      equipment.push(new Equipment('equipment3', 'PS4'))
    }
    if (+EquipmentMarshall == 1) {
      equipment.push(new Equipment('equipment4', 'Marshall amplification'))
    }
    if (+EquipmentKitchen == 1) {
      equipment.push(new Equipment('equipment5', 'kitchen'))
    }
    return equipment;
  }

  addAmenities({AmenitiesNoSrairs, AmenitiesEasyAccessParking, AmenitiesWideDoors, AmenitiesElevator, AmenitiesToilet}) {
    let amenities: AmenityForDisabled[] = [];
    if (+AmenitiesNoSrairs == 1) {
      amenities.push(new AmenityForDisabled('amenity1', 'no stairs entrance'))
    }
    if (+AmenitiesWideDoors == 1) {
      amenities.push(new AmenityForDisabled('amenity2', 'wide doors'))
    }
    if (+AmenitiesToilet == 1) {
      amenities.push(new AmenityForDisabled('amenity3', 'accessible toilet'))
    }
    if (+AmenitiesEasyAccessParking == 1) {
      amenities.push(new AmenityForDisabled('amenity4', 'easy access parking'))
    }
    if (+AmenitiesElevator == 1) {
      amenities.push(new AmenityForDisabled('amenity5', 'elevator'))
    }
    return amenities;
  }

  addActivities({ActivitiesMeetings, ActivitiesMusicBands, ActivitiesRolePlayingGames, ActivitiesRelaxation, ActivitiesCoWorking}) {
    let activities: Activity[] = [];
    if (+ActivitiesMeetings == 1) {
      activities.push(new Activity('activity1', 'corporate meetings'))
    }
    if (+ActivitiesRolePlayingGames == 1) {
      activities.push(new Activity('activity2', 'role playing games'))
    }
    if (+ActivitiesCoWorking == 1) {
      activities.push(new Activity('activity3', 'co-working'))
    }
    if (+ActivitiesMusicBands == 1) {
      activities.push(new Activity('activity4', 'music bands'))
    }
    if (+ActivitiesRelaxation == 1) {
      activities.push(new Activity('activity5', 'relaxation'))
    }
    return activities;
  }

  generatePhotoAsObject(photoUrl) {
    let photo = new Photo(photoUrl);
    photo.IsMain = true;
    let photoArray = [];
    photoArray.push(photo);
    return photoArray;
  }

  generateAddress({LocationBuildingNumber, LocationCity, LocationCountry, LocationPostaCode, LocationApartmentNumber, LocationStreet, LocationOtherInformation}) {
    return new RoomAddress(
      +LocationBuildingNumber,
      LocationCity,
      LocationCountry,
      +LocationPostaCode,
      +LocationApartmentNumber,
      LocationStreet,
      LocationOtherInformation);
  }

  getToken() {
    let newToken = JSON.parse(localStorage.getItem('userData'));
    let newToken1 = JSON.stringify(newToken);
    return newToken1;
  }

  isLoggedIn() {
    return this.dataStorageService.isLoggedIn;
  }
}
