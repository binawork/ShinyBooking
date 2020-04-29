import {RoomAddress} from './room-address.model';
import {Equipment} from '../rooms/equipment.model';

export class RoomForList {
  id?: string;
  area?: number;
  capacity?: number;
  equipments?: Array<Equipment>;
  mainPhotoUrl?: number;
  name?: string;
  price?: number;
  rating?: number;
  roomAddress?: RoomAddress;
}
