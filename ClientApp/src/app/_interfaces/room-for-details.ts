import {RoomAddress} from "./room-address";
import {Photo} from "./photo";
import {Equipment} from "./equipmen";
import {amenityForDisabled} from "./amenity-for-disabled";


export interface RoomForDetails {
  id?: string;
  name?: string;
  rating?: number;
  description?: string;
  roomArrangementsCapabilitiesDescription?: string;
  price?: number;
  area?: number;
  capacity?: number;
  parkingSpace?: boolean;
  photos?: Array<Photo>
  equipments?: Array<Equipment>;
  amenitiesForDisabled?: Array<amenityForDisabled>;
  addressForReturnDto?: RoomAddress;
}
