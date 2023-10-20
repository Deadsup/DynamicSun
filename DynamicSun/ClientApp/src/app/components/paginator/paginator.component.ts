import {Component, EventEmitter, Input, Output} from "@angular/core";

@Component({
  selector: 'app-paginator',
  templateUrl: './paginator.component.html',
  styleUrls: ['paginator.component.scss']
})

export class PaginatorComponent {
  @Input() totalItems: number = 10;
  @Input() itemsPerPage: number = 10;
  @Input() currentPage: number = 1;
  @Output() pageChanged = new EventEmitter<number>();

  get totalPages(): number {
    return Math.ceil(this.totalItems / this.itemsPerPage);
  }

  onPageChange(page: number): void {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
      console.log(this.currentPage)
      this.pageChanged.emit(this.currentPage);
    }
  }
}
