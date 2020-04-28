import {RoomAddress} from './room-address.model';
import {Photo} from './photo.model';
import {Equipment} from './equipment.model';
import {AmenityForDisabled} from './amenity-for-disabled.model';


export class RoomForDetails {
  id?: string;
  name?: string;
  rating?: number;
  description?: string;
  roomArrangementsCapabilitiesDescription?: string;
  price?: number;
  area?: number;
  capacity?: number;
  parkingSpace?: boolean;
  photos?: Array<Photo>;
  equipments?: Array<Equipment>;
  amenitiesForDisabled?: Array<AmenityForDisabled>;
  roomAddress?: RoomAddress;
}
