import { HttpClient, HttpEvent, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrlApi } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class FileuploadService {
  constructor(private http: HttpClient) { }
  getFiles(): Observable<any> {
    return this.http.get(`${baseUrlApi}/files`);
  }

}
