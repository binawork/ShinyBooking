import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions} from '@kolkov/ngx-gallery';
import {RoomService} from '../room.service';
import {RoomForDetails} from '../../shared/room-for-details.model';

@Component({
  selector: 'app-room-details',
  templateUrl: './room-details.component.html',
  styleUrls: ['../../styles.css']
})
export class RoomDetailsComponent implements OnInit {
  room: RoomForDetails;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

/*  ccc() {
    const API_KEY = 'zMm3X6j26T7vIcO5jBa0GfOjZGZC49bp';

    const GOLDEN_GATE_BRIDGE = {lng: -122.47483, lat: 37.80776};

    const map = tt.map({
      key: API_KEY,
      container: 'map-div',
      center: GOLDEN_GATE_BRIDGE,
      zoom: 12
    });
  }*/

  constructor(private roomService: RoomService,
              private route: ActivatedRoute,
              private router: Router,
              ) {
  }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.room = data.room;
      for(let photo of this.room.photos) {
        photo.PhotoUrl = photo.photoUrl;
      }

      console.log(this.room);
    });

    this.galleryOptions = [
      {
        width: '100%',
        height: '100%',
        thumbnails: false,
        arrowPrevIcon: 'fa fa-chevron-left',
        arrowNextIcon: 'fa fa-chevron-right',
        imageAnimation: NgxGalleryAnimation.Slide
      }];

    this.galleryImages = this.getImages();
  }

  getImages() {
    const imageUrls = [];
    for (const photo of this.room.photos) {
      imageUrls.push({
        small: photo.PhotoUrl,
        medium: photo.PhotoUrl,
        big: photo.PhotoUrl,
        description: photo.id
      });
    }
    // console.log(imageUrls);
    return imageUrls;
  }

  // loadRoom() {
  //   this.roomService.getRoom(this.router.snapshot.params['id'])
  //     .subscribe((room: RoomForDetails) => {
  //       this.room = room;
  //       console.log(this.room)
  //     }, error => {
  //       console.log(error)
  //     })
  // }

}
