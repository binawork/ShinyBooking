import {RoomAddress} from "./room-address";
import {Equipment} from "./equipmen";

export interface RoomForList {
  id?: string;
  name?: string;
  rating?: number;
  price?: number;
  area?: number;
  capacity?: number;
  mainPhotoUrl?: number;
  equipments?: Array<Equipment>;
  roomAddress?: RoomAddress;
}
