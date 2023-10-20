import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {WeatherSearchContext} from "../models/Filters/weatherSearchContext";


@Injectable()
export class WeatherService {
  private  url = "/api/weatherByDate"
  constructor(private http:HttpClient) {
  }

  uploadData(formData: FormData) {
    return this.http.post(this.url +'/uploadExel', formData)
  }

  getWeatherYears(){
    return this.http.get(this.url +'/years')
  }

  getWeather(queryParams: WeatherSearchContext) {
    let querystring = `?Order=${queryParams.order}&SortContext=${queryParams.sortContext}&Page=${queryParams.page}&Take=${queryParams.take}&Year=${queryParams.year}&Month=${queryParams.month}`
    return this.http.get(this.url + querystring)
  }
}
