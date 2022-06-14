import { Component, OnInit } from '@angular/core';
import {StationService} from "../../services/station.service";
import {Station} from "../../models/station.model";
import {Canton} from "../../models/canton.model";
import {CantonService} from "../../services/canton.service";
import {CantonStationService} from "../../services/canton-station.service";

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  stations: Station[] = [];
  cantons: Canton[] = [];
  selected: any;
  selectedCantonId!: string;
  selectedStationId!:string;
  selectedWaters!: string;

  constructor(private readonly stationService: StationService,
              private readonly cantonStationService: CantonStationService,
              private readonly cantonService: CantonService) { }

  ngOnInit(): void {
    this.getStationsOnly();
    this.getCantons();
  }

  getStationsOnly() {
    this.stationService.getStationsWhitCantonsOnly().subscribe({
      next: ((response) => {
        this.stations = response;
      }),
      error: (error) => {
        console.log(error);
      }
    });
  }

  getCantons() {
    this.cantonService.getCantons().subscribe({
      next: ((response) => {
        this.cantons = response;
      }),
      error: (error) => {
        console.log(error);
      }
    });
  }

  onStationChange(event: any) {
    // @ts-ignore
    this.selectedWaters = this.stations.find(s => s.id === event.target.value).name;
    this.selectedStationId = event.target.value;
  }

  onCantonChange(event: any) {
    this.selectedCantonId = event.target.value;
  }

  onAddCantonStation() {
    this.cantonStationService.insertCantonStation(this.selectedCantonId, this.selectedStationId).subscribe( {
      next: ((response) => {
        console.log(response);
        this.getStationsOnly();
      }),
      error: (error) => {
        console.log(error);
      }
    });
  }
}
