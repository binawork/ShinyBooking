import {Photo} from './photo.model';
import {Equipment} from '../rooms/equipment.model';
import {AmenityForDisabled} from '../rooms/amenity-for-disabled.model';
import {RoomAddress} from './room-address.model';

export class RoomToAddDto {



  constructor(
    public id: string,
    public name: string,
    public description: string,
    public roomArrangementsCapabilitiesDescription: string,
    public price: number,
    public area: number,
    public capacity: number,
    public parkingSpace: boolean,
    public photos: Photo[],
    //TODO make Asia and Wojtek correct backend to receive equipmentId and equipmentName (same fields for amenities)
    // public roomequipments: Equipment[],
    // public roomamenitiesForDisabled: AmenityForDisabled[],
    public roomAddress: RoomAddress,
    // public roomactivities = null,
  ) {
    //TODO unhardcode this two fields
    this.roomAddress.emailAddress = 'room@gmail.com';
    this.roomAddress.phoneNumber1 = '500014125';
  }

}
