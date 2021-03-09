import { Output } from '@angular/core';
import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { EventEmitter } from 'events';
import { Subject } from 'rxjs';
import { baseUrl, baseUrlApi } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private hubConnection: signalR.HubConnection;
  @Output()
  // public signalReceived = new EventEmitter<any>();

  private signalReceived = new Subject<any>(); // Source
  public eventCallback$ = this.signalReceived.asObservable(); // Stream

  constructor() {
    this.buildConnection();
    this.startConnection();
 }
  public buildConnection() {
    this.hubConnection = new signalR.HubConnectionBuilder().withUrl(baseUrl + 'MessageHub').build();
  }

  public startConnection() {
    this.hubConnection
      .start()
      .then(() => this.registerSignalREvent())
      .catch((err) => console.error('error while starting the connection:' + err));
  }

  private registerSignalREvent() {
    this.hubConnection.on('MessageReceived', (data: any) => {
      debugger;
      this.signalReceived.next(data);
      console.log(data);
    });
  }

}


