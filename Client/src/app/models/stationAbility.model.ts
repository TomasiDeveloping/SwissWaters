import {Measurement} from "./measurement.mode";

export interface StationAbility {
  id: string;
  stationId: string;
  name: string;
  unit: string;
  measurements: Measurement[];
}
