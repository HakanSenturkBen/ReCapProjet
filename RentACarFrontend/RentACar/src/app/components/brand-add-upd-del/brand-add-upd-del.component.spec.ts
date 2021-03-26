import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BrandAddUpdDelComponent } from './brand-add-upd-del.component';

describe('BrandAddUpdDelComponent', () => {
  let component: BrandAddUpdDelComponent;
  let fixture: ComponentFixture<BrandAddUpdDelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BrandAddUpdDelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BrandAddUpdDelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
