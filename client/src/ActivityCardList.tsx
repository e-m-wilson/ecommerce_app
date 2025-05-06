import { useEffect, useState } from "react"
import { Card, CardContent, Grid, Typography } from '@mui/material';
import { useTheme } from "@mui/material/styles";

export default function ActivityCardList() {

    const [activities, SetActivities] = useState<Activity[]>([]);
    const theme = useTheme();

    useEffect(() => {
        fetch('https://localhost:5500/api/activities')
            .then((r) => r.json())
            .then(data => SetActivities(data))


    }, [])
    return (
        <>
            <Typography variant="h1">My Activity List:</Typography>
            <Grid container spacing={2}>
                {activities.map((activity) => (
                    <Grid display="flex" size={{ xs: 12, sm: 6, md: 3, lg: 3 }}>
                        <Card key={activity.id} sx={{ width: 1, backgroundColor: theme.palette.primary.main, color: "white" }} variant="outlined">
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