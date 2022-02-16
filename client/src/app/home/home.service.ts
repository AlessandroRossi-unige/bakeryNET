import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from "@angular/common/http";
import {map} from "rxjs/operators";
import {IPagination} from "../shared/models/pagination";
import {ShopParams} from "../shared/models/shopParams";
import {ISweet} from "../shared/models/sweets";

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getSweets(shopParams: ShopParams) {
    let params = new HttpParams();

    if (shopParams.search) {
      params = params.append('search' , shopParams.search);
    }

    params = params.append('sort' , shopParams.sort);
    params = params.append('pageIndex', shopParams.pageIndex.toString());
    params = params.append('pageIndex', shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'sweets', {observe: 'response', params})
      .pipe(
      map(response => {
        return response.body;
      })
    );
  }

  getSweet(id: number) {
    return this.http.get<ISweet>(this.baseUrl + 'sweets/' + id);
  }

  deleteSweet(id: number) {
    console.log('delete');
    return this.http.delete<ISweet>(this.baseUrl + 'sweets/' + id);

  }
}
