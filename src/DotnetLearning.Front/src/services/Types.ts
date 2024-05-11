export type InImagePredict = {
  label: string;
  imageSource: string;
};

export type PredictionResult = {
  label: number;
  imageSource: string;
  predictedLabel: string;
  score: number[];
};
