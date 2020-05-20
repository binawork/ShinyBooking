export class Photo {
  id?: string;
  //photoUrl?: string;
  roomId?: string;
  // isMain?: boolean;
  // todo link do zdjęć
  // todo przycisk po prawej
  // zachowywanie danych po przeładowanie strony (session/localstorage)
  constructor(
    public PhotoUrl: string,
    public IsMain: boolean = false,
  ) {
  }
}
