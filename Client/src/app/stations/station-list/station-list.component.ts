import { Component, OnInit } from '@angular/core';
import {Station} from "../../models/station.model";
import {StationService} from "../../services/station.service";
import {Router} from "@angular/router";
import {CantonService} from "../../services/canton.service";

@Component({
  selector: 'app-station-list',
  templateUrl: './station-list.component.html',
  styleUrls: ['./station-list.component.css']
})
export class StationListComponent implements OnInit {
  stations: Station[] = [];
  filteredStations: Station[] = [];
  cantons: { name: string, code: string, selected: boolean }[] = [];
  selectedAll: boolean = true;
  search: string = '';
  currentWaterCount: number | undefined;
  session = false;
  userFavorites: string[] = [];

  constructor(private readonly stationService: StationService, private readonly router: Router, private readonly cantonService: CantonService) { }

  ngOnInit(): void {
    const checkUserFavorites = localStorage.getItem('userFavorites');
    if (checkUserFavorites) {
      this.userFavorites = JSON.parse(checkUserFavorites);
    }
    const sessionCantons = sessionStorage.getItem('userCantons');
    if (sessionCantons) {
      this.cantons = JSON.parse(sessionCantons);
      this.session = true;
    } else {
      this.setCantons();
    }
    this.getCurrentWaterTemperatures();
  }

  getCurrentWaterTemperatures() {
    this.stationService.getCurrentStationsData().subscribe({
      next: ((response) => {
        this.stations = response;
        this.filteredStations = response;
        this.currentWaterCount = response.length;
        if (this.session) {
          this.filterWaters();
        }
      }),
      error: (error) => {
        console.log(error);
      }
    });
  }

  setCantons() {
    this.cantonService.getCantons().subscribe({
      next: ((response) => {
        response.forEach((canton) => {
          this.cantons.push({
            name: canton.name,
            code: canton.code,
            selected: true
          });
        })
      }),
      error: (error) => {
        console.log(error);
      }
    });
  }

  selectAll() {
    this.selectedAll = !this.selectedAll;
    this.cantons.forEach(c => c.selected = this.selectedAll);
    if (this.selectedAll) {
      this.stations = this.filteredStations;
      sessionStorage.setItem('userCantons', JSON.stringify(this.cantons));
    }
    this.currentWaterCount = this.stations.length;
  }

  cantonChange(event: any) {
    const cantonName = event.target.value;
    let cantonToUpdate = this.cantons.find((c) => c.name === cantonName);
    if (!cantonToUpdate) {
      return;
    }
    cantonToUpdate.selected = !cantonToUpdate.selected;
    this.filterWaters();
  }

  filterWaters() {
    let cantonList = this.cantons.filter(c => c.selected);
    this.stations = this.filteredStations.filter((w) => {
        return cantonList.find((x) => (w.cantonName.indexOf(x.name) > -1));
      }
    )
    this.currentWaterCount = this.stations.length;
    sessionStorage.setItem('userCantons', JSON.stringify(this.cantons));
  }

  onDetail(station: Station) {
    this.router.navigate(["details", station.id]).then();
  }

  addToFavorite(id: number) {
    const userFavorites = localStorage.getItem('userFavorites');
    if (userFavorites) {
      this.userFavorites = JSON.parse(userFavorites);
      if (this.userFavorites.includes(id.toString())) {
        return;
      }
      this.userFavorites.push(id.toString());
      localStorage.setItem('userFavorites', JSON.stringify(this.userFavorites));
      return;
    }
    this.userFavorites.push(id.toString());
    localStorage.setItem('userFavorites', JSON.stringify(this.userFavorites));
  }

  removeFavorite(id: number) {
    const userFavorites = localStorage.getItem('userFavorites');
    if (userFavorites) {
      this.userFavorites = JSON.parse(userFavorites);
      this.userFavorites = this.userFavorites.filter(f => f !== id.toString())
      localStorage.setItem('userFavorites', JSON.stringify(this.userFavorites));
    }
  }

  checkFavorite(waterId: number) {
    return !this.userFavorites.includes(waterId.toString());
  }

  onlyFavorite(event: any) {
    if (event.target.checked) {
      this.stations = this.filteredStations.filter((w) => {
        return this.userFavorites.find((x) => w.id === x)
      })
      this.currentWaterCount = this.stations.length;
    } else {
      this.filterWaters();
    }
  }
}
