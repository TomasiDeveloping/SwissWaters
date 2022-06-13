import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";
import {Canton} from "../models/canton.model";

@Injectable({
  providedIn: 'root'
})
export class CantonService {

  private readonly apiUrl = environment.apiUrl + 'cantons/';

  constructor(private readonly http: HttpClient) { }

  getCantons(): Observable<Canton[]> {
    return this.http.get<Canton[]>(this.apiUrl);
  }
}
