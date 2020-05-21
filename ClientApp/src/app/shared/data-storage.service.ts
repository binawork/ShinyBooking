import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {RoomForDetails} from './room-for-details.model';
import {Observable} from 'rxjs';
import {RoomToAddDto} from './room-to-add-dto.model';
import { RegistrationModel } from './Registration.model';
import { LoginModel } from './Login.model';

@Injectable({
  providedIn: 'root'
})
export class DataStorageService {

  constructor(
    private http: HttpClient,
  ) {
  }

  private static convert(room: RoomForDetails): RoomToAddDto {
    return new RoomToAddDto(
      room.id,
      room.name,
      room.description,
      room.roomArrangementsCapabilitiesDescription,
      room.price,
      room.area,
      room.capacity,
      room.parkingSpace,
      room.photos,
      room.roomAddress,
    );
  }

    storeUser(user: RegistrationModel) {

    console.log(user);

    this.http
      .post('/api/accounts', user)

      .subscribe(response => {
        console.log('response:');
        console.log(response);
      });
  }

  storeLogin(login: LoginModel) {
    console.log(login);

    this.http
      .post('/api/auth/login', login)

      .subscribe(response => {
        console.log('response:');
        console.log(response);
      });
  }

  storeRoom(room: RoomForDetails) {
  // private static convert(room: RoomForDetails): RoomToAddDto {
  //   return new RoomToAddDto(
  //     room.id,
  //     room.name,
  //     room.description,
  //     room.roomArrangementsCapabilitiesDescription,
  //     room.price,
  //     room.area,
  //     room.capacity,
  //     room.parkingSpace,
  //     room.photos,
  //     room.roomAddress,
  //   );
  // }
//TODO metoda ma oczekiwać roomToAddDTO i ten obiekt wysyłać na serwer
  storeRoom(room: RoomToAddDto) {
    console.log('storeRoom()');
    // todo convert RoomForDetails to DTO version
    //const roomDto = DataStorageService.convert(room);
    console.log(room);
    // and send DTO version through API
    this.http
      .post('/api/rooms', room)
      // .pipe(
      //   catchError(this.handleError('addRoom', room))
      // )
      .subscribe(response => {
        console.log('response:');
        console.log(response);
      });
  }

  // I have no idea what this method should really do and return
  private handleError(action: string, room: RoomForDetails) {
    console.log(`Failed to add room:`);
    console.table(room);
    return (p1: any, p2: Observable<any>) => {
      return undefined;
    };
  }
}
