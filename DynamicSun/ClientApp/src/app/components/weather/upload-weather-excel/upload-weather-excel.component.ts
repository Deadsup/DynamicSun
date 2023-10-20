import {Component} from "@angular/core";
import {WeatherService} from "../../../services/weatherService";


@Component({
  selector: 'app-upload-weather-excel',
  templateUrl: 'upload-weather-excel.component.html',
  styleUrls: ['upload-weather-excel.scss']
})

export class UploadWeatherExcelComponent {

  files: File[] = []
  headerSelected: string = "Выбранный файл"

  constructor(private weatherService: WeatherService) {
  }
  onFileSelected(event: any){
    this.files = [...event.target.files]
    this.headerSelected = this.files.length > 1 ? "Выбранные файлы": this.headerSelected
  }

  onDeleteFile(selectedFile: File){
    this.files = this.files.filter(file => {
      return file.name != selectedFile.name
    })
  }

  uploadFiles(){
    let formData = new FormData()
    for(let i = 0; i < this.files.length; i++){
      let currentFile = this.files[i]
      formData.append(currentFile.name,currentFile,currentFile.name)
    }
    this.weatherService.uploadData(formData).subscribe(res => {
      console.log('vye', res)
    })
  }

}
