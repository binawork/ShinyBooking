import {Component, Injectable} from '@angular/core';
import {LoginComponent} from "../login/login.component";
import {DataStorageService} from "../shared/data-storage.service";

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css', './styles.css']


})

@Injectable({
  providedIn: 'root'
})
export class NavMenuComponent {

  loggedIn:boolean;
  loggedUserId: string = null;
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
