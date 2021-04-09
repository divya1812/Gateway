import { Card, Grid } from "@material-ui/core";
import React from "react";
import { useSelector } from "react-redux";
import Header from "./header";
import Inputtodo from "./inputtodo";
import Todolist from "./todolist";

const Main = () => {
  const listOfTodos = useSelector((state) => state);
  console.log(listOfTodos);

  return (
    <div
      style={{
        height: "100vh",
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        width: "100%",
        backgroundColor: "#818ee3",
      }}
    >
      <Card style={{ padding: "30px", marginTop: "20px" }}>
        <Grid container direction="column" alignItems="center" spacing={2}>
          <Grid item xs={12}>
            <Header />
          </Grid>
          <Grid item xs={12}>
            <Inputtodo />
          </Grid>
          <Grid item xs={12}>
            <Todolist todos={listOfTodos} />
          </Grid>
        </Grid>
      </Card>
    </div>
  );
};

export default Main;
