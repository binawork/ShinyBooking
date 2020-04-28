import {RoomAddress} from './room-address.model';
import {Equipment} from './equipment.model';

export class RoomForList {
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
