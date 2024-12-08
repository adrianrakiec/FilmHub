import { Search } from './Search';

export type SearchResponse = {
  search: Search[];
  totalResults: string;
  response: string;
};
