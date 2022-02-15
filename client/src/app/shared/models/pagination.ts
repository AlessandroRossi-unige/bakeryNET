import {ISweet} from "./sweets";

export interface IPagination {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: ISweet[];
}
