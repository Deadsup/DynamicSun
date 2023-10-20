import {DateSearchModel} from "./abstract/DateSearchModel";
import {WeatherSortContext} from "./enums/WeatherSortContext";
import {OrderSort} from "./enums/OrderSort";

export class WeatherSearchContext  extends DateSearchModel{
  sortContext: WeatherSortContext
  order: OrderSort
  constructor() {
    super();
    this.order = 0
    this.sortContext = 0
  }

}
