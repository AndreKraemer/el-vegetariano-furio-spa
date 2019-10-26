import { Component, OnInit } from '@angular/core';
import {ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-dish-list',
  templateUrl: './dish-list.component.html',
  styleUrls: ['./dish-list.component.css']
})
export class DishListComponent implements OnInit {
  categoryId = 0;
  constructor(
     private route: ActivatedRoute) { }

  ngOnInit() {
    this.categoryId = +this.route.snapshot.paramMap.get('categoryId');
  }

}
