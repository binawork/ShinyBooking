import {Component, Input, OnInit} from '@angular/core';
import {RoomForList} from '../../shared/room-for-list.model';

@Component({
  selector: 'app-room-card',
  templateUrl: './room-card.component.html',
  styleUrls: ['./room-card.component.css']
})
export class RoomCardComponent implements OnInit {
  @Input()
  public room: RoomForList;

  constructor() { }

  ngOnInit() {}
}
