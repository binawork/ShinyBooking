import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {RoomForDetails} from './room-for-details.model';
import {catchError} from 'rxjs/operators';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataStorageService {

  constructor(
    private http: HttpClient,
  ) {
  }

  storeRoom(room: RoomForDetails) {
    console.log('storeRoom()');
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
