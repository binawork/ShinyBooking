import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import {RouterModule} from '@angular/router';

import {AppComponent} from './app.component';
import {NavMenuComponent} from './nav-menu/nav-menu.component';
import {HomeComponent} from './home/home.component';
import {CounterComponent} from './counter/counter.component';
import {FetchDataComponent} from './fetch-data/fetch-data.component';
import {ApiAuthorizationModule} from 'src/api-authorization/api-authorization.module';
import {AuthorizeGuard} from 'src/api-authorization/authorize.guard';
import {AuthorizeInterceptor} from 'src/api-authorization/authorize.interceptor';
import {RoomService} from "./_services/room.service";
import {RoomCard} from "./rooms/room-card/room-card.component";
import { RoomListComponent } from './rooms/room-list/room-list.component';
import { FiltersBarComponent } from './filters-bar/filters-bar.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    RoomCard,
    RoomListComponent,
    FiltersBarComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      {path: '', component: RoomListComponent, pathMatch: 'full'},
      {path: 'counter', component: CounterComponent},
      {path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard]},
    ])
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true},
    RoomService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
