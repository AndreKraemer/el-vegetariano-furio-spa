import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DishEditComponent } from './dish-edit.component';

describe('DishEditComponent', () => {
  let component: DishEditComponent;
  let fixture: ComponentFixture<DishEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DishEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DishEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
