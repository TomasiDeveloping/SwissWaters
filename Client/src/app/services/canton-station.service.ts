import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class CantonStationService {

  private readonly apiUrl = environment.apiUrl + 'CantonStations/';

  constructor(private readonly http: HttpClient) { }

  insertCantonStation(cantonId: string, stationId: string): Observable<boolean> {
    const object = {
      cantonId: cantonId,
      stationId: stationId
    }
    return this.http.post<boolean>(this.apiUrl, object);
  }
}
