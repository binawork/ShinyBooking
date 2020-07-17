import { Component, ViewChild } from '@angular/core';
import { NgxCsvParser, NgxCSVParserError } from 'ngx-csv-parser';

@Component({
  selector: 'app-root',
  templateUrl: './room-csv.component.html',
  styleUrls: ['./room-csv.component.css']
})

export class RoomCsvComponent {

  csvRecords: any[] = [];
  header = false;

  constructor(private ngxCsvParser: NgxCsvParser) {
  }

  @ViewChild('fileImportInput') fileImportInput: any;

  fileChangeListener($event: any): void {

    const files = $event.srcElement.files;

    this.ngxCsvParser.parse(files[0], { header: this.header, delimiter: ',' })
      .pipe().subscribe((result: Array<any>) => {
        console.log('Result', result);
        this.csvRecords = result;
      }, (error: NgxCSVParserError) => {
        console.log('Error', error);
      });
  }
}
