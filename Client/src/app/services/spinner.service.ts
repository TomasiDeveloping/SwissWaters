import { Injectable } from '@angular/core';
import {NgxSpinnerService} from "ngx-spinner";

@Injectable({
  providedIn: 'root'
})
export class SpinnerService {
  busyRequestCount = 0;

  constructor(private spinnerService: NgxSpinnerService) {
  }

  busy(): void {
    this.busyRequestCount++;
    this.spinnerService.show(undefined, {
      type: 'line-scale-pulse-out-rapid',
      bdColor: 'rgba(0, 0, 0, 0.8)',
      color: '#7e6bec'
    }).then();
  }

  idle(): void {
    this.busyRequestCount--;
    if (this.busyRequestCount <= 0) {
      this.busyRequestCount = 0;
      this.spinnerService.hide().then();
    }
  }
}
