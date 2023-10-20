import {NgModule} from "@angular/core";
import {PaginatorComponent} from "./paginator.component";
import {FormsModule} from "@angular/forms";

@NgModule({
  imports: [
    FormsModule
  ],
  declarations: [PaginatorComponent],
  providers:[],
  exports: [PaginatorComponent]
})
export class PaginatorModule { }
