import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {RoomForDetails} from './room-for-details.model';
import {Observable} from 'rxjs';
import {RoomToAddDto} from './room-to-add-dto.model';
import { RegistrationModel } from './Registration.model';
import { LoginModel } from './Login.model';
import {NavMenuComponent} from "../nav-menu/nav-menu.component";
import {Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class DataStorageService {
  error: string = null;

  constructor(
    private http: HttpClient,
    private navMenuComponent: NavMenuComponent,
    private router: Router
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

  login(login: LoginModel) {
    console.log(login);

    this.http
      .post('/api/auth/login', login).subscribe(
      responseData => {
        console.log(responseData);
        this.navMenuComponent.loggedIn = true;
        this.router.navigate(["/rooms"]);
      }, error => {
        console.log(error);
        this.error=error.error.login_failure[0];
      }
    )
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
