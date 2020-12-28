import { HttpClient, HttpEvent, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrlApi } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class FileuploadService {
  // baseUrl = 'http://localhost:5000/api/';
  constructor(private http: HttpClient) { }

  // upload(file: File) {
  //   const formData: FormData = new FormData();

  //   formData.append('file', file);

  //   const req = new HttpRequest('POST', `${this.baseUrl}/upload`, formData, {
  //     reportProgress: true,
  //     responseType: 'json'
  //   });

  //   return this.http.post(this.baseUrl + 'product/Get', formData);


  //   return this.http.request(req);
  // }

  getFiles(): Observable<any> {
    return this.http.get(`${baseUrlApi}/files`);
  }

}
