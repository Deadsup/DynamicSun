import {NgModule} from "@angular/core";
import {WeatherTableComponent} from "./weather-table/weather-table.component";
import {WeatherService} from "../../services/weatherService";
import {CommonModule} from "@angular/common";
import {PaginatorModule} from "../paginator/paginator.module";
import {UploadWeatherExcelComponent} from "./upload-weather-excel/upload-weather-excel.component";
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from "@angular/material/button";
import {TooltipModule} from "primeng/tooltip";
import {FormsModule} from "@angular/forms";

@NgModule({
    imports: [
        CommonModule,
        PaginatorModule,
        MatIconModule,
        MatButtonModule,
        TooltipModule,
        FormsModule
    ],
  providers: [
    WeatherService
  ],
  declarations: [
    WeatherTableComponent,
    UploadWeatherExcelComponent
  ],
  exports: [
    WeatherTableComponent,
    UploadWeatherExcelComponent
  ]
})
export class WeatherModule {}
