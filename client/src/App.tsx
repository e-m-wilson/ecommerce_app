import { useEffect, useState } from "react"
import { Card, CardContent, Grid, Typography } from '@mui/material';
import './App.css';

function App() {
  const [activities, SetActivities] = useState<Activity[]>([]);

  useEffect(() => {
    fetch('https://localhost:5500/api/activities')
      .then((r) => r.json())
      .then(data => SetActivities(data))


  }, [])

  return (
    <>
      <h1>My App</h1>
      <Grid container spacing={2}>
        {activities.map((activity) => (
          <Grid display="flex" size={{ xs: 12, sm: 6, md: 3, lg: 3 }}>
            <Card key={activity.id} sx={{ width: 1, backgroundColor: "#009e96", color: "white" }} variant="outlined">
              <CardContent>
                <Typography>{activity.title}</Typography>
                <Typography>{activity.category}</Typography>
                <Typography>{activity.city}</Typography>
                <Typography>{activity.date}</Typography>
                <Typography>{activity.venue}</Typography>
              </CardContent>
            </Card>
          </Grid>
        ))}
      </Grid>


    </>
  )
}

export default App
