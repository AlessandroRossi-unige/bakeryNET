import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {HomeService} from "./home.service";
import {ISweet} from "../shared/models/sweets";
import {ShopParams} from "../shared/models/shopParams";
import {Observable} from "rxjs";
import {IUser} from "../shared/models/user";
import {AccountService} from "../account/account.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  @ViewChild('search', {static: true}) searchTerm: ElementRef;
  currentUser$: Observable<IUser>;
  shopParams = new ShopParams();
  sweets: ISweet[];
  totalCount: number;
  daysPassed = 0;
  sortOptions = [
    {name: 'Alphabetical', value:'name'},
    {name: 'Price: Low to High', value: 'priceAsc'},
    {name: 'Price: High to Low', value: 'priceDesc'},
  ];

  constructor(private homeService: HomeService, private accountService: AccountService) { }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
    this.getSweets();
    let lsDaysPassed = +localStorage.getItem('daysPassed');
    if (lsDaysPassed) this.daysPassed = lsDaysPassed;
    if (this.daysPassed >= 3) {
      localStorage.setItem('daysPassed', '0');
    }
  }

  getSweets() {
    this.homeService.getSweets(this.shopParams).subscribe(response => {
      this.sweets = response.data;
      console.log(response.data);
      this.shopParams.pageIndex = response.pageIndex;
      this.shopParams.pageSize = response.pageSize;
      this.totalCount = response.count;
    }, error => {
      console.log(error);
    })
  }

  onSortSelected(event: Event)
  {
    this.shopParams.sort = (event.target as HTMLInputElement).value;
    this.getSweets();
  }

  onPageChanged(event: any) {
    if (this.shopParams.pageIndex !== event) {
      this.shopParams.pageIndex = event;
      this.getSweets();
    }
  }

  onSearch() {
    this.shopParams.search = this.searchTerm.nativeElement.value;
    this.getSweets();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getSweets();
  }

  passDay() {

    this.daysPassed++;
    localStorage.setItem('daysPassed', this.daysPassed.toString());
    window.location.reload();
  }

  onAdd() {

  }

}
