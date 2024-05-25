import { useMutation } from "react-query";
import { useState } from "react";

import { TextField, Button, Card, Box, Typography } from "@mui/material";

import { Predict } from "./services/consumptionService";
import useStyles from "./styles";
import { PredictionResult } from "./services/Types";

function App() {
  const styles = useStyles();

  const [selectedFile, setSelectedFile] = useState<File | null>(null);
  const [response, setResponse] = useState<PredictionResult>();

  const { mutate, isLoading } = useMutation(
    "mutate-predict",
    async () => {
      if (!selectedFile) {
        throw new Error("Nenhum arquivo selecionado");
      }
      const base64String = await convertToBase64(selectedFile);
      return Predict({
        imageSource: base64String,
        label: "Imagem",
      });
    },
    {
      onSuccess: (data) => {
        setResponse(data ?? ({} as PredictionResult));
      },
    }
  );

  const convertToBase64 = (file: File): Promise<string> => {
    return new Promise((resolve, reject) => {
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => {
        if (reader.result && typeof reader.result === "string") {
          resolve(reader.result.split(",")[1]);
        } else {
          reject(new Error("Erro ao converter para base64"));
        }
      };
      reader.onerror = (error) => reject(error);
    });
  };

  const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files && event.target.files[0];
    if (file) {
      setSelectedFile(file);
    }
  };

    const handleSubmit = () => {
        setResponse({} as PredictionResult);
    mutate();
  };

  return (
    <Box sx={styles.root}>
      <Card sx={styles.rootCard}>
        <Box sx={styles.rootImagem}>
          {selectedFile && (
            <img
              src={URL.createObjectURL(selectedFile)}
              style={styles.image}
              alt="Imagem selecionada"
            />
          )}
        </Box>
        <Typography height="30px">
          <b>Objeto identificado:</b> {response?.predictedLabel}
          <br />
          <b>Eficiência:</b>{" "}
                  {`${(Math.max(...(response?.score ?? [0])) * 100).toFixed(2)}%`}
          <br />
          {isLoading && "Carregando resultado..."}
        </Typography>

        <Box sx={styles.rootRodape}>
          <TextField type="file" onChange={handleFileChange} />
          <Button variant="contained" onClick={handleSubmit} fullWidth>
            Enviar
          </Button>
        </Box>
      </Card>
    </Box>
  );
}

export default App;
