const useStyles = () => ({
  root: {
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
    width: "100vw",
    height: "100vh",
  },
  rootCard: {
    height: "50%",
    padding: 2,
    display: "flex",
    flexDirection: "column",
    justifyContent: "space-between",
    gap: 3,
  },
  rootImagem: {
    height: "40%",
    maxWidth: "100%",
  },
  image: {
    maxWidth: "350px",
    maxHeight: "100%",
    borderRadius: 10,
    border: "1px solid grey",
  },
  rootRodape: {
    display: "flex",
    padding: 1,
    gap: 2,
    flexDirection: "column",
  },
});

export default useStyles;
