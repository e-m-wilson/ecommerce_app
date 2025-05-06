import { ThemeProvider, createTheme } from "@mui/material/styles";
import './App.css';
import ActivityCardList from "./ActivityCardList";

const theme = createTheme({
  palette: {
    primary: {
      main: '#009e96'
    }
  }
});


function App() {
  
  return (
    <ThemeProvider theme={theme}>
      <ActivityCardList/>
    </ThemeProvider>


  )
}

export default App
