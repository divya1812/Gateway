import { Button, Grid } from "@material-ui/core";
import React, { useState } from "react";

import Todo from "./todo";

const Todolist = ({ todos }) => {
  const [filter, setFilter] = useState(null);
  const list = todos.filter((singletodo) => singletodo.isCompleted !== filter);
  const showAll = () => {
    setFilter(null);
  };
  const showActive = () => {
    setFilter(true);
  };
  const showComplete = () => {
    setFilter(false);
  };
  return (
    <>
      <div style={{ width: "400px", height: "500px", overflowY: "scroll" }}>
        <Grid container direction="row" justifyContent="center">
          <Grid
            item
            xs={12}
            container
            direction="row"
            justifyContent="center"
            spacing={2}
          >
            <Grid item xs={4}>
              <Button onClick={showAll}>All</Button>
            </Grid>
            <Grid item xs={4}>
              <Button onClick={showActive}>Active</Button>
            </Grid>
            <Grid item xs={4}>
              <Button onClick={showComplete}>Completed</Button>
            </Grid>
          </Grid>
          <Grid item xs={12}>
            {list && list.map((t) => <Todo todo={t} key={t.id} />)}
          </Grid>
        </Grid>
      </div>
      <Grid item>{`${list.length} todos left`}</Grid>
    </>
  );
};

export default Todolist;
