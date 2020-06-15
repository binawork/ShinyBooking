import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { Photo } from "../../shared/photo.model";
import { ImageshackResponse } from "./ImageshackResponseValidation/imageshack-response.model";

@Injectable({
  providedIn: 'root'
})
export class PhotosUploadService {
  addedPhotosURLs = [];
  addedPhotos = [];

  constructor(private http: HttpClient) {}

  uploadPhotos(event) {
    if(this.addedPhotosURLs.length > 0) {
      this.addedPhotosURLs.length = 0;
    }
    for (const photo of event.target.files) {
      if (this.isImage(photo)) {
        const fd = new FormData();
        fd.append('image', photo);
        fd.append('api_key', '049BDHIXe9596020c5f7240bd1b0dea114b8d937');
        this.http.post(
          'https://cors-anywhere.herokuapp.com/https://api.imageshack.com/v2/images', fd)
          .subscribe((res: ImageshackResponse) => {
            this.addedPhotosURLs.push(res.result.images[0].direct_link);
            console.log("Link: " + res.result.images[0].direct_link);
          });
      }
    }
  }

  //check if file is an image
  isImage(file) {
    return file && file['type'].split('/')[0] === 'image';
  }

  generatePhotosAsObjects() {

    for(let photoURL of this.addedPhotosURLs) {

      if (photoURL.substring(0, 7) !== 'http://' || photoURL.substring(0, 8) !== 'https://') {
        photoURL = 'http://' + photoURL;
      }

      this.addedPhotos.push(new Photo(photoURL));
    }
    if(this.addedPhotos.length ==0) {
      return null;
    }
    this.addedPhotos[0].IsMain = true;

    return this.addedPhotos;
  }

  getPhotosURLs() {
    return this.addedPhotosURLs;
  }

  clearAddedPhotos() {
    this.addedPhotosURLs = [];
    this.addedPhotos = [];
  }


}
