import { ThemeProvider, createTheme } from "@mui/material/styles";
import './App.css';
import ActivityCardList from "./ActivityCardList";
import Header from './Header';

const theme = createTheme({
  palette: {
    primary: {
      main: '#479e9d',
    },
    secondary: {
      main: '#d07b7e',
    }
  }
});


function App() {
  
  return (
    <ThemeProvider theme={theme}>
      <Header />
      <div style={{margin: "30px"}}>
        <ActivityCardList />
      </div>
      
    </ThemeProvider>


  )
}

export default App
