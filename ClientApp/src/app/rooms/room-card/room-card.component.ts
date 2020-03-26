import {Component, Input, OnInit} from '@angular/core';
import {RoomForList} from "../../_interfaces/room-for-list";

@Component({
  selector: 'app-room-card',
  templateUrl: './room-card.component.html',
  styleUrls: ['./room-card.component.css']
})
export class RoomCard implements OnInit {
  @Input()
  public room: RoomForList;

  constructor() { }

  ngOnInit() {}
}
