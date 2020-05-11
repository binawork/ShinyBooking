import {Inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ActivatedRoute} from '@angular/router';
import {RoomForList} from '../shared/room-for-list.model';
import {AmenityForDisabled} from './amenity-for-disabled.model';
import {Equipment} from './equipment.model';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  private readonly amenitiesForDisabled = [
    new AmenityForDisabled('reserved parking'),
    new AmenityForDisabled('zero-step entries'),
    new AmenityForDisabled('width doors'),
    new AmenityForDisabled('virtual keyboard'),
    new AmenityForDisabled('refreshable braille display'),
    new AmenityForDisabled('screen reader'),
  ];
  private readonly equipment = [
    new Equipment('dryer'),
    new Equipment('dish washer'),
    new Equipment('projector'),
    new Equipment('whiteboard'),
    new Equipment('sewing machine'),
    new Equipment('coffee machine'),
  ];

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
}


