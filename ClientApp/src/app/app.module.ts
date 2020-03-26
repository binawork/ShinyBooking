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
import {RoomDetailsResolver} from "./_resolvers/room-details.resolver";
import {NgxGalleryModule} from "@kolkov/ngx-gallery";

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
    NgxGalleryModule,
    FormsModule,


    RouterModule.forRoot([
      {path: '', component: RoomListComponent, pathMatch: 'full'},
      {path: 'rooms', component: RoomListComponent, pathMatch: 'full'},
      {path: 'rooms/:id', component: RoomDetailsComponent, resolve: {room: RoomDetailsResolver}},
    ])
  ],
  providers: [
    RoomService,
    RoomDetailsResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
