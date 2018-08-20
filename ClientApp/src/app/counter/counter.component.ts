import { Component, ViewChild, ElementRef } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse } from '@angular/common/http'

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  currentCount = 0;
  data: any = [];
  files: any;
  isNotFileCSV: boolean;

  @ViewChild('file') file: ElementRef;
  constructor(private http: HttpClient) { }

  incrementCounter() {
    this.currentCount++;
  }

  clear() {
    this.data = [];
    this.files = null;
    this.file.nativeElement.value = '';
  }

  uploadOnChange(files) {
    if (files && files[0].name.indexOf('csv') < 0) {
      this.isNotFileCSV = true;
    } else {
      this.isNotFileCSV = false;
      this.files = files;
    }
  }

  upload() {
    if (!this.files || this.files.length === 0) {
      return;
    }

    const formData = new FormData();

    for (let file of this.files) {
      formData.append(file.name, file);
    }

    const uploadReq = new HttpRequest('POST', `api/SampleData/UploadFile`, formData, {
      reportProgress: true,
    });

    this.http.request(uploadReq)
      .subscribe((response: any) => {
        if (response.body) {
          this.data = response.body;
        }
      });

  }
}
