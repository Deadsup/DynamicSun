import {Component, OnInit, ViewChild} from "@angular/core";
import {WeatherByHours} from "../../../models/weatherByHours";
import {WeatherService} from "../../../services/weatherService";
import {WeatherSearchContext} from "../../../models/Filters/weatherSearchContext";
import {PaginatorComponent} from "../../paginator/paginator.component";
import {OrderSort} from "../../../models/Filters/enums/OrderSort";
import {WeatherSortContext} from "../../../models/Filters/enums/WeatherSortContext";


@Component({
  selector: "weather-table",
  templateUrl: "weather-table.component.html",
  styleUrls: ['weather-table.component.scss']
})

export class WeatherTableComponent implements OnInit{

  weatherCount: number = 0
  years: number[] = []
  weatherList: WeatherByHours[] = []
  pages: string[] = []
  queryParams: WeatherSearchContext = new WeatherSearchContext()
  @ViewChild('paginator') paginator : PaginatorComponent | undefined;


  constructor(private weatherService: WeatherService) { }

  ngOnInit() {
    this.getWeatherPage()
    this.getYears()
  }



  getWeatherPage(){
    this.weatherService.getWeather(this.queryParams).subscribe({next: (data: any) => {
        let value = data["value"]
        this.weatherCount = value["count"]
        this.weatherList = value["weatherByHoursList"]
      }
    });
  }

  onChangePage(event: number){
    this.queryParams.page = event
    this.getWeatherPage()
  }

  getYears(){
    this.weatherService.getWeatherYears().subscribe({next: (data: any) => {
        this.years = data["value"]
      }
    });
  }

  onSelectMonth(event: any){
    this.queryParams.month = event.target.value
  }

  onSelectYear(event: any){
    this.queryParams.year = event.target.value
  }

  onSelectOrder(orderBy: string){
    switch (orderBy){
      case this.queryParams.sortContext.toString():
        let order = this.queryParams.order
        this.queryParams.order =  order == OrderSort.Ascending ? OrderSort.Descending : OrderSort.Ascending
        break;
      case  "0":
      case  "1":
        this.queryParams.sortContext = WeatherSortContext.Date
        break;
      case  "2":
        this.queryParams.sortContext = WeatherSortContext.WindSpeed
        break;
      case  "3":
        this.queryParams.sortContext = WeatherSortContext.Temperature
        break;
      default:
        this.queryParams.order = OrderSort.Ascending
        this.queryParams.sortContext = WeatherSortContext.None
        break
    }
    this.getWeatherPage()

  }
  onSelect(event: any){
    this.queryParams.take = event.target.value
    if(this.paginator)
      this.paginator.itemsPerPage = this.queryParams.take
    this.getWeatherPage()
  }

  onFiltersApply(){
    this.getWeatherPage()
  }

  onFilterClear(){
    this.queryParams.month = 0
    this.queryParams.year = 0
    this.queryParams.take = 10
  }
}
