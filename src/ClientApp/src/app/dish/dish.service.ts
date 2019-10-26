import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Dish } from './dish';

@Injectable({
  providedIn: 'root'
})
export class DishService {

  constructor(private http: HttpClient) { }

  getDish(id: number): Observable<Dish> {
    return this.http.get<Dish>(`/api/dishes/${id}`);
  }

  updateDish(dish: Dish): Observable<Dish> {
    return this.http.put<Dish>(`/api/dishes/${dish.id}`, dish);
  }

  createDish(dish: Dish): Observable<Dish> {
    return this.http.post<Dish>('/api/dishes/', dish);
  }

  deleteDish(id: number): Observable<object> {
    return this.http.delete(`/api/dishes/${id}`);
  }
}
