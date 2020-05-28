import {Component, Injectable, OnDestroy, OnInit} from '@angular/core';
import {Subscription} from "rxjs";

import {DataStorageService} from "../shared/data-storage.service";
import {User} from "../login/user.model";

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css', './styles.css']
})

@Injectable({
  providedIn: 'root'
})
export class NavMenuComponent implements OnInit, OnDestroy {
  public userSub: Subscription;
  loggedUserName: string;

  constructor(
    private dataStorageService: DataStorageService) {}

  ngOnInit(): void {
    this.userSub = this.dataStorageService.user.subscribe((user: User) => {
      this.setLoggedIn(!!user);
      this.setLoggedUserName(user.userName);
    });
  }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  onLogout() {
    this.dataStorageService.logout();
  }

  ngOnDestroy() {
    this.userSub.unsubscribe();
  }

  isLoggedIn() {
    return this.dataStorageService.isLoggedIn;
  }

  setLoggedIn(value: boolean) {
    this.dataStorageService.isLoggedIn = value;
  }

  getLoggedUserName() {
    return this.dataStorageService.loggedUserName;
  }

  setLoggedUserName(userName: string) {
    this.dataStorageService.loggedUserName = userName;
  }

}
