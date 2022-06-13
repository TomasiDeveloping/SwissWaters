import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";
import {Station} from "../models/station.model";

@Injectable({
  providedIn: 'root'
})
export class StationService {

  private readonly apiUrl = environment.apiUrl + 'waters/';

  constructor(private http: HttpClient) { }

  getCurrentStationsData(): Observable<Station[]> {
    return this.http.get<Station[]>(this.apiUrl + 'GetCurrentStationsData')
  }

  getStationById(stationId: string): Observable<Station> {
    let params = new HttpParams();
    params = params.set('dayIncluded', 7);
    return this.http.get<Station>(this.apiUrl + stationId, {params});
  }
}
