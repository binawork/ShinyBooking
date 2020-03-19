import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomCard } from './room-card.component';

describe('RoomCardForListComponent', () => {
  let component: RoomCard;
  let fixture: ComponentFixture<RoomCard>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RoomCard ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RoomCard);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
