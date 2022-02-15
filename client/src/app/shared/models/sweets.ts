import {IIngredient} from "./ingredients";

export interface ISweet {
  id: number,
  name: string,
  description: string;
  price: number;
  ingredients: IIngredient[],
  pictureUrl: string
}
