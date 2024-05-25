import { InImagePredict, PredictionResult } from "./Types";

export const Predict = async (
  body: InImagePredict
): Promise<PredictionResult | undefined> => {
  const response = await fetch("https://localhost:7059/predict", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(body),
  });

  if (!response.ok) {
    throw new Error("Network response was not ok");
  }

  const data = (await response.json()) as PredictionResult; // Converter para PredictionResult

  console.log(data); // Verifica os dados

  return data; // Retorna os dados
};
