import { Component, OnInit } from '@angular/core';
import { DishService } from '../dish/dish.service';
import { ActivatedRoute } from '@angular/router';
import { Dish } from '../dish/dish';
import { Location } from '@angular/common';

@Component({
  selector: 'app-dish-edit',
  templateUrl: './dish-edit.component.html',
  styleUrls: ['./dish-edit.component.css']
})
export class DishEditComponent implements OnInit {
  dish: Dish;
  constructor(private route: ActivatedRoute, private dishService: DishService, private location: Location) { }

  ngOnInit() {
    const dishId = +this.route.snapshot.paramMap.get('dishId');
    this.dishService
      .getDish(dishId)
      .subscribe(dish => this.dish = dish);
  }

  saveDish() {
    this.dishService
      .updateDish(this.dish)
      .subscribe(() => this.location.back());
  }

  deleteDish() {
    this.dishService
      .deleteDish(this.dish.id)
      .subscribe(() => this.location.back());
  }

  back() {
    this.location.back();
  }

}
