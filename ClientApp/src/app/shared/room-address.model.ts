export class RoomAddress {
  public id?: string;
  public emailAddress?: string;
  public phoneNumber1?: string;

  constructor(
    public buildingNumber: number,
    public city: string,
    public country: string,
    public postalCode: number,
    public apartmentNumber: number,
    public street: string,
    public otherAddressInformation: string
  ) {
  }
}
