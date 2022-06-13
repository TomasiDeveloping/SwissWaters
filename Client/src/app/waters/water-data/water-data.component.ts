import {Component, Input, OnInit} from '@angular/core';
import {WaterData} from "../../models/waterData.model";

@Component({
  selector: 'app-water-data',
  templateUrl: './water-data.component.html',
  styleUrls: ['./water-data.component.css']
})
export class WaterDataComponent implements OnInit {

  @Input() waterData!: WaterData;
  constructor() { }

  ngOnInit(): void {
  }

}
