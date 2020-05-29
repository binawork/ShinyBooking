import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Subject} from 'rxjs';
import {RoomToAddDto} from './room-to-add-dto.model';
import {RegistrationModel} from './Registration.model';
import {LoginModel} from './Login.model';

import {Router} from "@angular/router";
import {User} from "../login/user.model";
import {BackendLoginResponse} from "../login/backend-login-response.model";
import {take} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class DataStorageService {

  error: string = null;
  user = new Subject<User>();
  private _isLoggedIn = false;
  private _loggedUserName: string;
  private tokenExpirationTimer: any;

  constructor(
    private http: HttpClient,
    private router: Router
  ) {
  }

  registerUser(user: RegistrationModel) {
    this.http
      .post('/api/accounts', user)
      .subscribe(response => {
          console.log("Resp" + response);
        }
      );
  }

  storeRoom(room: RoomToAddDto) {
    console.log(room);
    // and send DTO version through API
    this.http
      .post('/api/rooms', room)
      .subscribe(response => {
        console.log('response:');
        console.log(response);
      });
  }

  login(login: LoginModel) {
    this.http
      .post('/api/auth/login', login)
      .subscribe((resData: BackendLoginResponse) => {
          this.handleAuthentication(resData.id, resData.userName, resData.auth_token, +resData.expires_in)
          this.router.navigate(['/rooms']);
        }, error => {
          console.log(error);
          this.error = error.error.login_failure[0];
        }
      )
  }

  autoLogin() {
    const userData: {
      id: string;
      userName: string;
      _token: string;
      _tokenExpirationDate: string;
    } = JSON.parse(localStorage.getItem('userData'));
    if (!userData) {
      return;
    }
    const loadedUser = new User(
      userData.id,
      userData.userName,
      userData._token,
      new Date(userData._tokenExpirationDate));

    if (loadedUser.token) {
      this.user.next(loadedUser);
      const expirationDuration = new Date(userData._tokenExpirationDate).getTime() - new Date().getTime();
      this.autoLogout(expirationDuration);
      this.isLoggedIn = true;
      this.loggedUserName = loadedUser.userName;
    }
  }

  logout() {
    this.user.next(null);
    this.isLoggedIn = false;
    this.loggedUserName = null;
    localStorage.removeItem('userData');
    if (this.tokenExpirationTimer) {
      clearTimeout(this.tokenExpirationTimer);
    }
    this.tokenExpirationTimer = null;
  }

  autoLogout(expirationDuration: number) {
    this.tokenExpirationTimer = setTimeout(() => {
      this.logout();
    }, expirationDuration)
  }

  private handleAuthentication(userId: string, userName: string, authToken: string, expiresIn: number) {
    const expirationDate = new Date(new Date().getTime() + +expiresIn * 1000);
    const user = new User(userId, userName, authToken, expirationDate);
    this.user.next(user);
    this.autoLogout(expiresIn * 1000);
    localStorage.setItem('userData', JSON.stringify(user));
    this.isLoggedIn = true;
    this.loggedUserName = user.userName;
  }

  get isLoggedIn(): boolean {
    return this._isLoggedIn;
  }

  set isLoggedIn(value: boolean) {
    this._isLoggedIn = value;
  }

  get loggedUserName(): string {
    return this._loggedUserName;
  }

  set loggedUserName(value: string) {
    this._loggedUserName = value;
  }
}
