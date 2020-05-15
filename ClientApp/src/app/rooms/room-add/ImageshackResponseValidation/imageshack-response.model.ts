import {ImageshackResult} from "./imageshack-result.model";

export class ImageshackResponse {
  success: boolean;
  process_time: number;
  result: ImageshackResult;


  constructor() {
  }
}
