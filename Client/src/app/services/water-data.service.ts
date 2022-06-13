import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {WaterData} from "../models/waterData.model";

@Injectable({
  providedIn: 'root'
})
export class WaterDataService {
  private readonly apiUrl = environment.apiUrl + 'waterData/';

  constructor(private readonly http: HttpClient) { }

  getWaterDataById(waterDataId: string): Observable<WaterData> {
    return this.http.get<WaterData>(this.apiUrl + waterDataId);
  }
}
