import { Component } from '@angular/core';
import {DataService} from "./WeatherService";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [DataService]
})
export class HomeComponent {

  someFile: File | undefined

  constructor(private dataService: DataService) {
  }

  get(){
    this.dataService.get().subscribe(res => {
      console.log(res)
    })
  }
 inputFile(event: FileList){
  console.log(event)
   let file = event[0]
   let formData = new FormData()
   formData.append(file.name, file, file.name)

   this.dataService.uploadData(formData).subscribe(res => {

   })
 }
}
