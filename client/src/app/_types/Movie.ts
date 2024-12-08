import { Metadata } from './Metadata';

export type Movie = {
  id: number;
  title: string;
  isWatched: boolean;
  dateWatched: string | null;
  userNotes: string;
  metadata: Metadata;
};
