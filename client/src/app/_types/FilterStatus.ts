export type FilterStatus =
  | FilterOption.All
  | FilterOption.Watched
  | FilterOption.NotWatched;

export enum FilterOption {
  All = 'all',
  Watched = 'watched',
  NotWatched = 'notWatched',
}
