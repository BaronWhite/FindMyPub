import { IPubReview } from "./pub-review";
import { IPubSummary } from "./pub-summary";


export interface IPub extends IPubSummary {
  reviews: IPubReview[];
}
