import {Component, Input, OnInit} from '@angular/core';
import {ISweet} from "../../shared/models/sweets";
import {HomeService} from "../home.service";
import {AccountService} from "../../account/account.service";
import {Observable} from "rxjs";
import {IUser} from "../../shared/models/user";

@Component({
  selector: 'app-sweet-item',
  templateUrl: './sweet-item.component.html',
  styleUrls: ['./sweet-item.component.scss']
})
export class SweetItemComponent implements OnInit {
  @Input() sweet: ISweet;
  @Input() daysPassed: number;
  currentUser$: Observable<IUser>
  baseUrl = 'https://localhost:5001/';

  constructor(private homeService: HomeService, private accountService: AccountService) { }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
    let days = this.calculateDaysBetween();
    this.sweet.initialPrice = this.sweet.price;
    this.sweet.price = this.calculateDiscount(this.sweet.price, days);
  }

  private calculateDaysBetween() {
    let date = new Date(Date.parse(this.sweet.creationDate));
    let diffInTime = date.getTime() - Date.now();
// To calculate the no. of days between two dates
    let diffInDays = Math.round(diffInTime / (1000 * 3600 * 24));
    console.log(Math.round(diffInDays));
    return diffInDays < 0 ? 0 : diffInDays;
  }

  private calculateDiscount(price: number, days: number) {
    if (this.daysPassed) days = days + this.daysPassed;
    if (days === 0) return price;
    if (days === 1) return price * 0.8;
    if (days === 2) return price *0.2;
    if (days >= 3) this.deleteSweet();
  }

  deleteSweet() {
    this.homeService.deleteSweet(this.sweet.id).subscribe(response => {
      console.log(response.id);
      window.location.reload();
    });
    ;

  }
}
