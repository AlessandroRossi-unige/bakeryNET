import {Component, Input, OnInit} from '@angular/core';
import {ISweet} from "../../shared/models/sweets";

@Component({
  selector: 'app-sweet-item',
  templateUrl: './sweet-item.component.html',
  styleUrls: ['./sweet-item.component.scss']
})
export class SweetItemComponent implements OnInit {
  @Input() sweet: ISweet
  baseUrl = 'https://localhost:5001/';

  constructor() { }

  ngOnInit(): void {
  }

}
