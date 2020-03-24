import { __decorate } from "tslib";
import { Component } from '@angular/core';
let RoomListComponent = class RoomListComponent {
    constructor(roomService) {
        this.roomService = roomService;
    }
    ngOnInit() {
        this.roomService.getRooms().subscribe(rooms => {
            this.roomList = rooms;
            console.log(rooms);
        });
    }
};
RoomListComponent = __decorate([
    Component({
        selector: 'app-room-list',
        templateUrl: './room-list.component.html',
        styleUrls: ['./room-list.component.css']
    })
], RoomListComponent);
export { RoomListComponent };
//# sourceMappingURL=room-list.component.js.map