import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Room} from "../_interfaces/room";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getRooms() :Observable<Array<Room>>{
    return this.http.get<Array<Room>>(this.baseUrl + '/api/rooms')
  }

}


