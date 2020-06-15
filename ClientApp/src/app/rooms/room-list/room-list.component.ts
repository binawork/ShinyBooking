import {Component, HostListener, OnInit} from '@angular/core';
import {RoomService} from '../room.service';
import {RoomForList} from '../../shared/room-for-list.model';
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-room-list',
  templateUrl: './room-list.component.html',
  styleUrls: ['./styles.css']
})
export class RoomListComponent implements OnInit {
  roomList: Array<RoomForList>;
  addedRoom: string;
  innerWidth: any;

  constructor(private roomService: RoomService, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.roomService.getRooms().subscribe(rooms => {
      this.roomList = rooms;
      console.log(rooms);
    });

    this.route.queryParams.subscribe(params => {
      this.addedRoom = params['addedRoom'];
    });

    this.innerWidth = window.innerWidth;
  }

  @HostListener('window:resize', ['$event'])
  onResize(event) {
    this.innerWidth = window.innerWidth;
  }

}
