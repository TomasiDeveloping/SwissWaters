import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient, HttpParams} from "@angular/common/http";
import {catchError, EMPTY, Observable, shareReplay} from "rxjs";
import {Station} from "../models/station.model";

@Injectable({
  providedIn: 'root'
})
export class StationService {

  private readonly apiUrl = environment.apiUrl + 'stations/';
  stationCache!: Observable<Station[]>;
  expires!: number;


  constructor(private http: HttpClient) { }

  getCurrentStationsData(): Observable<Station[]> {
    if (this.getCacheStations()) {
      return this.getCacheStations()!;
    }
    let observable = this.http.get<Station[]>(this.apiUrl + 'GetLatestMeasurements').pipe(
      shareReplay(1),
      catchError(_ => {
        return EMPTY;
      })
    );
    this.setCache(observable);
    return observable;

  }

  getCacheStations(): Observable<Station[]> | null {
    let cacheStations = this.stationCache;

    if (!cacheStations) {
      return null;
    }
    if (this.expires <= Date.now()) {
      return null;
    }

    return cacheStations;
  }

  setCache(value: Observable<Station[]>): void {
    // Cache set 10Minutes
    this.expires = Date.now() + 600000;
    this.stationCache = value;
  }


  getStationsWhitCantonsOnly(): Observable<Station[]> {
    return this.http.get<Station[]>(this.apiUrl);
  }

  getStationById(stationId: string): Observable<Station> {
    let params = new HttpParams();
    params = params.set('dayIncluded', 7);
    return this.http.get<Station>(this.apiUrl + stationId, {params});
  }
}
