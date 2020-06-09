import {Photo} from "../../shared/photo.model";
import {Equipment} from "../equipment.model";
import {AmenityForDisabled} from "../amenity-for-disabled.model";
import {Activity} from "../activity.model";
import {RoomAddress} from "../../shared/room-address.model";

export class RoomAddServerResponse {
  id: string;
  name: string;
  rating: number;
  description: string;
  roomArrangementsCapabilitiesDescription: string;
  price: number;
  area: number;
  capacity: number;
  parkingSpace: boolean;
  photos: Photo[];
  roomEquipments: Equipment[];
  roomAmenitiesForDisables: AmenityForDisabled[];
  roomActivities: Activity[];
  roomAddress: RoomAddress;
  customer: any;

  constructor() {
  }
}
