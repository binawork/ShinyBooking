import {Injectable} from "@angular/core";
import {ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot} from "@angular/router";
import {RoomForDetails} from "../_interfaces/room-for-details";
import {Observable, of} from "rxjs";
import {RoomService} from "../_services/room.service";
import {catchError} from "rxjs/operators";

@Injectable()
export class RoomDetailsResolver implements Resolve<RoomForDetails>{

  constructor(private roomService: RoomService, private router: Router) {
  }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<RoomForDetails> | Promise<RoomForDetails> | RoomForDetails {
    return this.roomService.getRoom(route.params['id']).pipe(
      catchError(error => {
        console.log("Problem retrieving data (error from room-details-resolver) room-details-resolver", error);
        this.router.navigate(['/rooms']);
        return of(null)
      })
    )
  }

}
