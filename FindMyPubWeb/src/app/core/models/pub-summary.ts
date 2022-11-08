import { IPubLocation } from "./pub-location";

export interface IPubSummary {
  id: number;
  name: string;
  category: string;
  thumbnail: string;
  location: IPubLocation;
  url: string;
  phone: string;
  twitter: string;
  tags: string[];
  starsBeer: number;
  starsAtmosphere: number;
  starsAmenities: number;
  starsValue: number;
}
