import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from "@angular/router";
import {Injectable} from "@angular/core";
import {Observable} from "rxjs";
import {DataStorageService} from "../shared/data-storage.service";
import {map, take} from "rxjs/operators";

@Injectable({providedIn: 'root'})
export class LoginGuard implements CanActivate {
  constructor(private dataStorageService: DataStorageService, private router: Router) {
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    router: RouterStateSnapshot
  ):
    | boolean
    | UrlTree
    | Promise<boolean | UrlTree>
    | Observable<boolean | UrlTree> {
    return this.dataStorageService.user.pipe(
      take(1),
      map(user => {
        const isLoggedIn = !!user;
        if (isLoggedIn) {
          return true;
        }
        return this.router.createUrlTree(['/login']);
      })
    );
  }
}
