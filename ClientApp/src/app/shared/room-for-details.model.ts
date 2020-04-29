import {Photo} from './photo.model';
import {AmenityForDisabled} from '../rooms/amenity-for-disabled.model';
import {Equipment} from '../rooms/equipment.model';
import {RoomAddress} from './room-address.model';


export class RoomForDetails {
  id?: string;
  amenitiesForDisabled?: Array<AmenityForDisabled>;
  area?: number;
  capacity?: number;
  name?: string;
  description?: string;
  equipments?: Array<Equipment>;
  parkingSpace?: boolean;
  photos?: Array<Photo>;
  price?: number;
  rating?: number;
  roomAddress?: RoomAddress;
  roomArrangementsCapabilitiesDescription?: string;
}
