import { Component, OnInit } from '@angular/core';
import {Station} from "../../models/station.model";
import {ChartConfiguration, ChartType} from "chart.js";
import {ActivatedRoute, Params} from "@angular/router";
import {StationService} from "../../services/station.service";
import {StationAbility} from "../../models/stationAbility.model";
import 'chartjs-adapter-date-fns';
import {de} from 'date-fns/locale';


@Component({
  selector: 'app-station-detail',
  templateUrl: './station-detail.component.html',
  styleUrls: ['./station-detail.component.css']
})
export class StationDetailComponent implements OnInit {

  stationId!: string;
  currentStation!: Station;
  waterTemperatures: StationAbility | undefined;

  delayed: any;
  label: string = 'Temperaturen letzten 7 Tage';
  lineChartType: ChartType = 'line';
  lineChartOptions: ChartConfiguration['options'] = {
    elements: {
      line: {
        tension: 0.5
      }
    },
    locale: 'de',
    animation: {
      onComplete: () => {
        this.delayed = true;
      },
      delay: (context) => {
        let delay = 0;
        if (context.type === 'data' && context.mode === 'default' && !this.delayed) {
          delay = context.dataIndex * 4 + context.datasetIndex * 100;
        }
        return delay;
      },
    },
    interaction: {
      intersect: false,
      mode: "index"
    },
    scales: {
      x: {
        adapters: {
          date: { locale: de}
        },
        type: "time",
        time: {
          unit: "day",
          displayFormats: {
            day: "dd.MM.yyyy"
          },
          tooltipFormat: 'dd.MM.yyyy HH:mm',
        }
      },
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
        backgroundColor: 'rgba(250,112,26,0.2)',
        borderColor: 'rgb(236,140,39)',
        pointBackgroundColor: 'rgb(16,15,15)',
        pointBorderColor: '#fff',
        pointHoverBackgroundColor: '#fff',
        pointHoverBorderColor: 'rgba(148,159,177,0.8)',
        fill: 'origin',
        pointStyle: "circle",
        pointRadius: 0
      },
    ],
    labels: []
  };
  constructor(private readonly route: ActivatedRoute,
  private readonly stationService: StationService,) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => this.stationId = params['id']);
    this.getCurrentWater(this.stationId);
  }

  getCurrentWater(stationId: string) {
    this.stationService.getStationById(stationId).subscribe({
      next: ((response) => {
        this.currentStation = response;
        // if (response.watersTypeName === 'See') {
        //   this.getWaterData(response.id);
        // }
        const temperatureAbility = response.stationAbilities.find(s => s.name.includes("Wassertemperatur"));
        if (temperatureAbility) {
          this.waterTemperatures = temperatureAbility;
          this.waterTemperatures.measurements.forEach((m) => {
            this.lineChartData.datasets[0].data.unshift(m.value);
            this.lineChartData.labels?.unshift(new Date(m.measurementTime));
          })
        }
        // response.measurements.forEach((m) => {
        //   this.lineChartData.datasets[0].data.unshift(m.temperature);
        //   this.lineChartData.labels?.unshift(new Date(m.measurementTime).toLocaleDateString('de-DE'))
        // }
        // );
      }),
      error: (error) => {
        console.log(error);
      }
    });
  }

  // getWaterData(waterDataId: string) {
  //   this.waterDataService.getWaterDataById(waterDataId).subscribe({
  //     next: ((response) => {
  //       this.waterData = response;
  //     })
  //   });
  // }

}
