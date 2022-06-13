export interface Measurement {
  id: string;
  stationAbilityId: string;
  measurementTime: Date;
  value: number;
  max24H?: number;
  min24H?: number;
  mean24H?: number;
}
