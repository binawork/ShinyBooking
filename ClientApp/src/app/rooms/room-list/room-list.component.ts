import {Component, OnInit} from '@angular/core';
import {RoomService} from '../../_services/room.service';
import {RoomForList} from '../../shared/room-for-list.model';

@Component({
  selector: 'app-room-list',
  templateUrl: './room-list.component.html',
  styleUrls: ['./room-list.component.css']
})
export class RoomListComponent implements OnInit {
  roomList: Array<RoomForList>;

  constructor(private roomService: RoomService) {
  }

  ngOnInit() {
    this.roomService.getRooms().subscribe(rooms => {
      this.roomList = rooms;
      console.log(rooms);
    });
  }

}
