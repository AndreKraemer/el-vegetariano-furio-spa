import { Dish } from "../dish/dish";

export interface Category {
    id: number;
    name: string;
    description: string;
    dishes: Dish[];
}
