export class RoomAddress {
  constructor(
    public buildingNumber: number,
    public city: string,
    public country: string,
    public postalCode: number,
    public id: string = null,
    public apartmentNumber: number = null,
    public street: string = null,
  ) {
  }
}
