import { Component, OnInit } from '@angular/core';
import {Station} from "../../models/station.model";
import {ActivatedRoute, Params} from "@angular/router";
import {StationService} from "../../services/station.service";
import {WaterData} from "../../models/waterData.model";
import {WaterDataService} from "../../services/water-data.service";
import {ChartConfiguration, ChartType} from "chart.js";

@Component({
  selector: 'app-station-detail',
  templateUrl: './station-detail.component.html',
  styleUrls: ['./station-detail.component.css']
})
export class StationDetailComponent implements OnInit {

  stationId!: string;
  currentStation!: Station;
  waterData: WaterData | undefined;

  label: string = 'Temperaturen letzten 7 Tage';
  lineChartType: ChartType = 'line';
  lineChartOptions: ChartConfiguration['options'] = {
    elements: {
      line: {
        tension: 0.5
      }
    },
    scales: {
      x: {},
      'y-axis-0':
        {
          position: 'left',
        },
    },
  }
  lineChartData: ChartConfiguration['data'] = {
    datasets: [
      {
        data: [],
        label: '°C',
        backgroundColor: 'rgba(26,26,250,0.2)',
        borderColor: 'rgb(18,10,248)',
        pointBackgroundColor: 'rgb(16,15,15)',
        pointBorderColor: '#fff',
        pointHoverBackgroundColor: '#fff',
        pointHoverBorderColor: 'rgba(148,159,177,0.8)',
        fill: 'origin',
      },
    ],
    labels: []
  };

  constructor(private readonly route: ActivatedRoute,
              private readonly stationService: StationService,
              private readonly waterDataService: WaterDataService) {
  }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => this.stationId = params['id']);
    this.getCurrentWater(this.stationId);
  }

  getCurrentWater(stationId: string) {
    this.stationService.getStationById(stationId).subscribe({
      next: ((response) => {
        this.currentStation = response;
        if (response.watersTypeName === 'See') {
          this.getWaterData(response.id);
        }
        response.measurements.forEach((m) => {
          this.lineChartData.datasets[0].data.unshift(m.temperature);
          this.lineChartData.labels?.unshift(new Date(m.measurementTime).toLocaleDateString('de-DE'))
        }
        );
      }),
      error: (error) => {
        console.log(error);
      }
    });
  }

  getWaterData(waterDataId: string) {
    this.waterDataService.getWaterDataById(waterDataId).subscribe({
      next: ((response) => {
        this.waterData = response;
      })
    });
  }
}
