import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import {WeatherTableComponent} from "./components/weather/weather-table/weather-table.component";
import {NavMenuComponent} from "./components/nav-menu/nav-menu.component";
import {WeatherModule} from "./components/weather/weather.module";
import {UploadWeatherExcelComponent} from "./components/weather/upload-weather-excel/upload-weather-excel.component";

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavMenuComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    WeatherModule,
    RouterModule.forRoot([
      {path: '', component: HomeComponent},
      {path: 'weatherByDate', component: WeatherTableComponent},
      {path: 'upload-weather-excel', component: UploadWeatherExcelComponent}
    ])
  ],
  providers: [],
  exports: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
