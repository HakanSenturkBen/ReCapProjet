import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarAddUpdDelComponent } from './car-add-upd-del.component';

describe('CarAddUpdDelComponent', () => {
  let component: CarAddUpdDelComponent;
  let fixture: ComponentFixture<CarAddUpdDelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarAddUpdDelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CarAddUpdDelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
