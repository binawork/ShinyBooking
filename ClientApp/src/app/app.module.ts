import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from "@angular/common/http";
import {FormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";


import { AppComponent } from './app.component';
import {RoomListComponent} from "./rooms/room-list/room-list.component";
import {RoomService} from "./_services/room.service";
import {NavMenuComponent} from "./nav-menu/nav-menu.component";
import {RoomCard} from "./rooms/room-card/room-card.component";
import {FiltersBarComponent} from "./filters-bar/filters-bar.component";
import { RoomDetailsComponent } from './rooms/room-details/room-details.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    RoomCard,
    RoomListComponent,
    FiltersBarComponent,
    RoomDetailsComponent,

  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,

    RouterModule.forRoot([
      {path: '', component: RoomListComponent, pathMatch: 'full'},
      {path: 'room-list', component: RoomListComponent, pathMatch: 'full'},
    ])
  ],
  providers: [
    RoomService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
