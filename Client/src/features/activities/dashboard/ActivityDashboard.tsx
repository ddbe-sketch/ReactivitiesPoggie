import { Grid2 } from "@mui/material";
import ActivityList from "./ActivityList";
import ActivityFilter from "./ActivityFilters";

export default function ActivityDashboard() {
  return (
    <Grid2 container spacing={3}>
      <Grid2 size={8}>
        <ActivityList />
      </Grid2>
      <Grid2
        size={4}
        sx={{
          position: "sticky",
          top: 112,
          alignSelf: "flex-start",
        }}
      >
        <ActivityFilter />
      </Grid2>
    </Grid2>
  );
}
