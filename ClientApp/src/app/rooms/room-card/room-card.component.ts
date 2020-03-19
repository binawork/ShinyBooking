import {Component, Input, OnInit} from '@angular/core';
import {Room} from "../../_interfaces/room";

@Component({
  selector: 'app-room-card',
  templateUrl: './room-card.component.html',
  styleUrls: ['./room-card.component.css']
})
export class RoomCard implements OnInit {
  @Input()
  public room: Room;

  constructor() { }

  ngOnInit() {}
}
