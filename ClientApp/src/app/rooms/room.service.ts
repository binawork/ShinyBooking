import {Inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ActivatedRoute} from '@angular/router';
import {RoomForList} from '../shared/room-for-list.model';
import {AmenityForDisabled} from './amenity-for-disabled.model';
import {Equipment} from './equipment.model';
import {Activity} from "./activity.model";

@Injectable({
  providedIn: 'root'
})
export class RoomService {
  fetchedAmenities: any;
  fetchedEquipments: any;
  fetchedActivities: any;

  private readonly amenitiesForDisabled = [
    new AmenityForDisabled('amenity1', 'no stairs entrance'),
    new AmenityForDisabled('amenity2', 'wide doors'),
    new AmenityForDisabled('amenity3', 'accessible toilet'),
    new AmenityForDisabled('amenity4', 'easy access parking'),
    new AmenityForDisabled('amenity5', 'elevator')
  ];

  private readonly equipment = [
    new Equipment('equipment1', 'fax machine'),
    new Equipment('equipment2', 'coffee machine'),
    new Equipment('equipment3', 'PS4'),
    new Equipment('equipment4', 'Marshall amplification'),
    new Equipment('equipment5', 'kitchen')
  ];

  private readonly activities = [
    new Activity('activity1', 'corporate meetings'),
    new Activity('activity2', 'role playing games'),
    new Activity('activity3', 'co-working'),
    new Activity('activity4', 'music bands'),
    new Activity('activity5', 'relaxation'),
  ]

  private readonly baseUrl: string;

  constructor(private http: HttpClient,
              @Inject('BASE_URL') baseUrl: string,
              private route: ActivatedRoute) {
    this.baseUrl = baseUrl;
  }

  getRooms(): Observable<Array<RoomForList>> {
    return this.http.get<Array<RoomForList>>(this.baseUrl + '/api/rooms');
  }

  getRoom(id): Observable<RoomForList> {
    return this.http.get<RoomForList>(this.baseUrl + '/api/rooms/' + id);
  }

  getAmenitiesForDisabled(): AmenityForDisabled[] {
    return this.amenitiesForDisabled.slice(); // slice() so original object will be unchanged
  }


  getEquipment(): Equipment[] {
    return this.equipment.slice();
  }

  getActivities(): Activity[] {
    return this.activities.slice();
  }

/*  getAmenitiesForDisabled(): Observable<Array<AmenityForDisabled>> {
    return this.http.get<AmenityForDisabled[]>(this.baseUrl + '/api/AmenitiesForDisabled');
  }

  getEquipment(): Observable<Array<Equipment>> {
    return this.fetchedEquipments = this.http.get<Equipment[]>(this.baseUrl + '/api/Equipments');
  }

  getActivities(): Observable<Array<Activity>> {
    return this.fetchedActivities = this.http.get<Activity[]>(this.baseUrl + '/api/Activities');
  }*/

}


