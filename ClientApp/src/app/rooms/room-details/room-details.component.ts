import {Component, OnInit} from '@angular/core';
import {RoomService} from "../../_services/room.service";
import {ActivatedRoute, Router} from "@angular/router";
import {RoomForDetails} from "../../_interfaces/room-for-details";
import {NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions} from "@kolkov/ngx-gallery";
import {Equipment} from "../../_interfaces/equipmen";

@Component({
  selector: 'app-room-details',
  templateUrl: './room-details.component.html',
  styleUrls: ['./room-details.component.css', './osahan.css']
})
export class RoomDetailsComponent implements OnInit {
  room: RoomForDetails;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];
  equipmentColumnsForView: Array<Array<String>>;

  constructor(private roomService: RoomService, private router: ActivatedRoute, private routerr: Router) {
  }

  ngOnInit(): void {
    this.router.data.subscribe(data => {
      this.room = data['room'];
      this.equipmentColumnsForView = this.createEquipmentRowsForView();
      console.log(this.equipmentColumnsForView[0][0])
      console.log('CHECK!')
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
    for (let photo of this.room.photos) {
      imageUrls.push({
        small: photo.photoUrl,
        medium: photo.photoUrl,
        big: photo.photoUrl,
        description: photo.id
      });
    }
    console.log(imageUrls);
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

  createEquipmentRowsForView() {
    let columnsArray = Array<Array<String>>(3);
    columnsArray[0] = new Array<String>()
    columnsArray[1] = new Array<String>()
    columnsArray[2] = new Array<String>()
    let eqs = this.room.equipments;
    for (let i = 0; i < columnsArray.length; i++) {
      let counter = i;
      while(counter < eqs.length) {
        columnsArray[i].push(eqs[counter].name)
        counter += 3
      }
    }
    return columnsArray
  }
}
