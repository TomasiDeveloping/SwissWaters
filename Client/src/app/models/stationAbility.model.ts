import {Measurement} from "./measurement.model";

export interface StationAbility {
  id: string;
  stationId: string;
  name: string;
  unit: string;
  measurements: Measurement[];
}
