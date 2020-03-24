import { __decorate, __param } from "tslib";
import { Inject, Injectable } from '@angular/core';
let RoomService = class RoomService {
    constructor(http, baseUrl) {
        this.http = http;
        this.baseUrl = baseUrl;
    }
    getRooms() {
        return this.http.get(this.baseUrl + '/api/rooms');
    }
};
RoomService = __decorate([
    Injectable({
        providedIn: 'root'
    }),
    __param(1, Inject('BASE_URL'))
], RoomService);
export { RoomService };
//# sourceMappingURL=room.service.js.map