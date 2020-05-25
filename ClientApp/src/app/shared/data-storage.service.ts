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

    storeUser(user: RegistrationModel) {

    console.log(user);

    this.http
      .post('/api/accounts', user)

      .subscribe(response => {
        console.log('response:');
        console.log(response);
      });
  }
// todo zmienić nazwę funkcji
  storeLogin(login: LoginModel) {
    console.log(login);

    this.http
      .post('/api/auth/login', login)

      .subscribe(response => {
        console.log('response:');
        console.log(response);
      });
  }


  storeRoom(room: RoomToAddDto) {
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
