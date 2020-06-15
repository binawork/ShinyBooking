import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {RouterModule} from '@angular/router';


import {AppComponent} from './app.component';
import {RoomListComponent} from './rooms/room-list/room-list.component';
import {RoomService} from './rooms/room.service';
import {NavMenuComponent} from './nav-menu/nav-menu.component';
import {RoomCardComponent} from './rooms/room-list/room-card/room-card.component';
import {FiltersBarComponent} from './filters-bar/filters-bar.component';
import {RoomDetailsComponent} from './rooms/room-details/room-details.component';
import {RoomDetailsResolver} from './_resolvers/room-details.resolver';
import {NgxGalleryModule} from '@kolkov/ngx-gallery';
import {RoomAddComponent} from './rooms/room-add/room-add.component';
import { LoginComponent } from './login/login.component';
import {RegistrationFormComponent} from './registration/registration-form.component';
import {LoginGuard} from "./login/login.guard";
import {SafeStylePipe} from "./rooms/room-details/safe-style.pipe";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    RoomCardComponent,
    RoomListComponent,
    FiltersBarComponent,
    RoomDetailsComponent,
    RoomAddComponent,
    LoginComponent,
    RegistrationFormComponent,
    SafeStylePipe

  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    NgxGalleryModule,
    FormsModule,
    ReactiveFormsModule,


    RouterModule.forRoot([
      {path: '', component: RoomListComponent, pathMatch: 'full'},
      {path: 'room/:id', component: RoomDetailsComponent, resolve: {room: RoomDetailsResolver}},
      {path: 'add-new-room', component: RoomAddComponent}, //canActivate: [LoginGuard]},
      {path: 'rooms', component: RoomListComponent, pathMatch: 'full'},
      {path: 'login', component: LoginComponent},
      {path: 'register', component: RegistrationFormComponent},
    ])
  ],
  providers: [
    RoomService,
    RoomDetailsResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
