import { Component, OnInit } from '@angular/core';
import {Room} from "../../_interfaces/room";
import {RoomService} from "../../_services/room.service";

@Component({
  selector: 'app-room-list',
  templateUrl: './room-list.component.html',
  styleUrls: ['./room-list.component.css']
})
export class RoomListComponent implements OnInit {
  roomList: Array<Room>;
  constructor(private roomService: RoomService) { }

  ngOnInit() {
    this.roomService.getRooms().subscribe(rooms => {
      this.roomList = rooms;
    })
  }

}
