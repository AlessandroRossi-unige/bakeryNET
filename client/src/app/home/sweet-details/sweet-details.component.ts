import { Component, OnInit } from '@angular/core';
import {ISweet} from "../../shared/models/sweets";
import {HomeService} from "../home.service";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-sweet-details',
  templateUrl: './sweet-details.component.html',
  styleUrls: ['./sweet-details.component.scss']
})
export class SweetDetailsComponent implements OnInit {
  sweet: ISweet;
  baseUrl = 'https://localhost:5001/';

  constructor(private homeService: HomeService, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadSweet();
  }

  loadSweet() {
    this.homeService.getSweet(+this.activatedRoute.snapshot.paramMap.get('id')).subscribe(sweet => {
      this.sweet = sweet;
    }, error => {
      console.log(error);
    });
  }

}
