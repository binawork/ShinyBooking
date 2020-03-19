import {Equipment} from "./equipment";
import {RoomAddress} from "./room-address";

export interface Room {
  id?: string;
  name?: string;
  rating?: number;
  price?: number;
  area?: number;
  capacity?: number;
  mainPhotoUrl?: number;
  equipmentsForReturnListDto?: Array<Equipment>;
  addressForReturnDto?: RoomAddress;
}
