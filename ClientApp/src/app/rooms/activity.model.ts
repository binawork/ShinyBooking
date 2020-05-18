export class Activity {
  public ActivitiesId: string;
  public name: string;

  constructor(
    ActivitiesId: string,
    name: string
  ) {
    this.ActivitiesId = ActivitiesId;
    this.name = name;
  }
}
