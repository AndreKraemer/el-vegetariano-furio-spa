import { Component, OnInit } from '@angular/core';
import {ActivatedRoute } from '@angular/router';
import { Dish } from '../dish/dish';
import { CategoryService } from '../category/category.service';
import { Category } from '../category/category';

@Component({
  selector: 'app-dish-list',
  templateUrl: './dish-list.component.html',
  styleUrls: ['./dish-list.component.css']
})
export class DishListComponent implements OnInit {
  category: Category;
  constructor(
     private route: ActivatedRoute,
     private categoryService: CategoryService) { }

  ngOnInit() {
    const categoryId = +this.route.snapshot.paramMap.get('categoryId');
    this.categoryService
      .getCategory(categoryId)
      .subscribe(category => this.category = category);
  }

}
