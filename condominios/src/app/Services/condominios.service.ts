import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Client } from '../models/client';
import { BehaviorSubject, Observable } from 'rxjs';
import { Residential } from '../models/Residential';

@Injectable({
  providedIn: 'root'
})
export class CondominiosService {
  myAppUrl = 'https://localhost:44341/';
  myApiUrl = 'api/Clients/';
  //myApiUrl2 = 'api/Residential/';
  list!: Client[];
  //list2!: Residential[];

  private updateForm = new BehaviorSubject<Client>({} as any);
  //private updateResidentialForm = new BehaviorSubject<Residential>({} as any);

  constructor(private http: HttpClient) { }

  saveClient(client: Client): Observable<Client> {
    return this.http.post<Client>(this.myAppUrl + this.myApiUrl, client);
  }

  GetClients() {
    this.http.get(this.myAppUrl + this.myApiUrl).toPromise()
             .then(data => {
                this.list = data as Client[];
               console.log(this.list);
             });
  }


  updateClient(id: number, client: Client): Observable<Client> {
    return this.http.put<Client>(this.myAppUrl + this.myApiUrl + id, client);
  }

  deleteClient(id: number): Observable<Client> {
    return this.http.delete<Client>(this.myAppUrl + this.myApiUrl + id);
  }

   update(client: any) {
    this.updateForm.next(client);
  }

  getClient$(): Observable<Client> {
    return this.updateForm.asObservable();
  }

  /* saveResidential(residential: Residential): Observable<Residential> {
    return this.http.post<Residential>(this.myAppUrl + this.myApiUrl2, residential);
  }

  getResidentials() {
    this.http.get(this.myAppUrl + this.myApiUrl2).toPromise()
                  .then(data => {
                    this.list2 = data as Residential[];
                  });
  }

  updateResidential(id: number, residential: Residential): Observable<Residential> {
    return this.http.put<Residential>(this.myAppUrl + this.myApiUrl2 + id, residential);
  }

  deleteResidential(id: number): Observable<Residential> {
    return this.http.delete<Residential>(this.myAppUrl + this.myApiUrl2 + id);
  }

  update2(residential: any) {
    this.updateResidentialForm.next(residential);
  }

  getResidential$(): Observable<Residential> {
    return this.updateResidentialForm.asObservable();
  } */
}
