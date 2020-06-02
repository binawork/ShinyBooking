export class UserToken {
  constructor(
    public id: string,
    public userName: string,
    private _token: string,
    private _tokenExpirationDate: number,
    private _tokenExpirationDateAsDate : Date
  ) {
  }

  get token() {
    if (!this._tokenExpirationDateAsDate || new Date() > this._tokenExpirationDateAsDate) {
      return null;
    }

    return this._token;

  }

}
