import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DishCreateComponent } from './dish-create.component';

describe('DishCreateComponent', () => {
  let component: DishCreateComponent;
  let fixture: ComponentFixture<DishCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DishCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DishCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
