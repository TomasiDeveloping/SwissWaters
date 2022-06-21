import { Component, OnInit } from '@angular/core';
import {ApiUser} from "../models/apiUser.model";
import {AuthService} from "../services/auth.service";


@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  currentUser!: ApiUser;

  constructor(private readonly authService: AuthService) { }

  ngOnInit(): void {
    this.authService.currentUser.subscribe({
      next: ((response) => {
        if (response != null) {
          this.currentUser = response;
        }
      })
    });
  }

}
