import {Component, OnInit, EventEmitter, Output} from '@angular/core';
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
  //@Output() notifyDelete: EventEmitter<string> = new EventEmitter<string>();
  confirmDelete = false;

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

  deleteRoom() {
    this.roomService.deleteRoom(this.room.id).subscribe(
      () => console.log(`Room with id = ${this.room.id} deleted`),
      (err) => console.log(err));
    //this.notifyDelete.emit(this.room.id);
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
