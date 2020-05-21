import {Component, OnInit} from '@angular/core';
import {RoomService} from '../room.service';
import {RoomForList} from '../../shared/room-for-list.model';

@Component({
  selector: 'app-room-list',
  templateUrl: './room-list.component.html',
  styleUrls: ['./styles.css']
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
