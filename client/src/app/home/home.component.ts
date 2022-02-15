import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {HomeService} from "./home.service";
import {ISweet} from "../shared/models/sweets";
import {ShopParams} from "../shared/models/shopParams";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  @ViewChild('search', {static: true}) searchTerm: ElementRef;
  shopParams = new ShopParams();
  sweets: ISweet[];
  totalCount: number;
  sortOptions = [
    {name: 'Alphabetical', value:'name'},
    {name: 'Price: Low to High', value: 'priceAsc'},
    {name: 'Price: High to Low', value: 'priceDesc'},
  ];

  constructor(private homeService: HomeService) { }

  ngOnInit(): void {
    this.getSweets();

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

}
