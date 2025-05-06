import { useEffect, useState } from "react"

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
      <ul>
        {activities.map((activity) => (
          <li key={activity.id}>{activity.title}</li>
        ))}
      </ul>
    </>
  )
}

export default App
