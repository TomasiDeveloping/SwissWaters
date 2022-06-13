import {StationAbility} from "./stationAbility.model";

export interface Station {
  id: string;
  name: string;
  watersName: string;
  watersTypeName: string;
  easting: number;
  northing: number;
  cantonName: string[];
  stationAbilities: StationAbility[];
}
