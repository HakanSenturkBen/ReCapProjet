import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ColorAddUpdDelComponent } from './color-add-upd-del.component';

describe('ColorAddUpdDelComponent', () => {
  let component: ColorAddUpdDelComponent;
  let fixture: ComponentFixture<ColorAddUpdDelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ColorAddUpdDelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ColorAddUpdDelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
