export interface WaterData {
  id: number;
  waterName: string;
  description: string;
  area?: number;
  volume?: number;
  maximumDepth?: number;
  altitudeAboveSeaLevel?: number;
  imageUrl?: string;
}
