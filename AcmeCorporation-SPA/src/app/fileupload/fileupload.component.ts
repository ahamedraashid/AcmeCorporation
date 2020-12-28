import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-fileupload',
  templateUrl: './fileupload.component.html',
  styleUrls: ['./fileupload.component.scss']
})
export class FileuploadComponent implements OnInit {

  mydata = [];
  files: File[];
  onSelectFile(event) {
    this.files = event.target.files;
    console.log(this.files);
    }

  ngOnInit() {
  }

  public get getFiles() {
    return this.files;
  }

//   public sendFiles(files: File[]) {
//     console.log(files);
//     const formData = new FormData();
//     for (let i; i < files.length; i++) {
//       formData.append('files[]', files[i]);
//     }

//     console.log(formData);
//     // files.
//     // formData.append('Files', files);
//     // files.forEach(element => {
//     //   // formData.append('files[]', element);
//     // });
//  }

}
