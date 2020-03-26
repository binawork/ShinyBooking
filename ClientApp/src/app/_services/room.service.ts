import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {ActivatedRoute} from "@angular/router";
import {RoomForList} from "../_interfaces/room-for-list";

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute) {
    this.baseUrl = baseUrl;
  }

  getRooms() :Observable<Array<RoomForList>>{
    return this.http.get<Array<RoomForList>>(this.baseUrl + '/api/rooms')
  }

  getRoom(id) : Observable<RoomForList>{
    return this.http.get<RoomForList>(this.baseUrl + '/api/rooms/' + id)
  }
}


