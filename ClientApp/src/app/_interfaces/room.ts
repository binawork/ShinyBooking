import {Equipment} from "./equipment";

export interface Room {
  id?: string;
  name?: string;
  rating?: number;
  price?: number;
  area?: number;
  capacity?: number;
  mainPhotoUrl?: number;
  equipmentsForReturnListDto?: Array<Equipment>;
}
