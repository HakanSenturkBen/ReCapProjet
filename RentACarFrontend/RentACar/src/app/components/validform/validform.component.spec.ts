import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ValidformComponent } from './validform.component';

describe('ValidformComponent', () => {
  let component: ValidformComponent;
  let fixture: ComponentFixture<ValidformComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ValidformComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ValidformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
