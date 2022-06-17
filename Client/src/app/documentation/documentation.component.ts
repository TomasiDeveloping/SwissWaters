import {AfterViewInit} from '@angular/core';
import { Component } from '@angular/core';
// @ts-ignore
import SwaggerUI from 'swagger-ui';
import customerApiDoc from '../../assets/customerAPI-1.0.json';

@Component({
  selector: 'app-documentation',
  templateUrl: './documentation.component.html',
  styleUrls: ['./documentation.component.css']
})
export class DocumentationComponent implements AfterViewInit  {

  constructor() { }

  ngAfterViewInit() {
    SwaggerUI({
      spec: customerApiDoc,
      domNode: document.getElementById('swagger'),
      presets: [
        SwaggerUI.presets.apis
      ]
    });
  }
}
