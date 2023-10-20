import {Pagination} from "./Pagination";

export  class  DateSearchModel extends Pagination{
  month: number
  year: number
  constructor() {
    super()
    this.month = 0
    this.year = 0
  }
}
