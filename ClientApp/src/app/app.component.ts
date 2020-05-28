import { Component, OnInit } from '@angular/core';
import {DataStorageService} from "./shared/data-storage.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./styles.css']
})
export class AppComponent implements OnInit {
  constructor(private dataStorageService: DataStorageService) {}

  title = 'MainPage';

  ngOnInit() {
    this.dataStorageService.autoLogin();
  }
}
