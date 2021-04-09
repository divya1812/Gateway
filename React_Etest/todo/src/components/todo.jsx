import React, { useState } from "react";
import { deleteItem, editItem, updateStatus } from "../store/actions/action";
import { useDispatch } from "react-redux";
import CheckCircleIcon from "@material-ui/icons/CheckCircle";
import EditIcon from "@material-ui/icons/Edit";
import {
  Button,
  Card,
  CardContent,
  Grid,
  IconButton,
  TextField,
  Tooltip,
  Typography,
} from "@material-ui/core";
import DeleteIcon from "@material-ui/icons/Delete";
const Todo = ({ todo }) => {
  const [isEditOn, setEditOn] = useState(false);
  const [editValue, seteditValue] = useState(todo.title);
  const dispatch = useDispatch();
  console.log(editValue);
  const setEditValue = (e) => {
    seteditValue(e.target.value);
  };
  const handleDelete = () => {
    dispatch(deleteItem(todo.id));
  };
  const handleComplete = () => {
    dispatch(updateStatus(todo.id));
  };
  const handleEdit = () => {
    dispatch(editItem(todo.id, editValue));
    setEditOn(false);
  };
  const toggleEdit = () => {
    setEditOn(true);
  };
  return (
    <div>
      {isEditOn ? (
        <div style={{ marginBottom: "20px" }}>
          <Grid container spacing={2} alignItems="center">
            <Grid item>
              <TextField
                onChange={setEditValue}
                value={editValue}
                id="outlined-basic"
                variant="outlined"
              />
            </Grid>
            <Grid item>
              <Button onClick={handleEdit}>Save</Button>
            </Grid>
          </Grid>
        </div>
      ) : (
        <>
          <Card style={{ width: "100%", marginBottom: "20px" }}>
            <CardContent style={{ padding: 10 }}>
              <Grid container alignitems="center">
                <Grid item container alignItems="center" xs={7}>
                  <Grid item>
                    <Typography variant="subtitle1" onDoubleClick={toggleEdit}>
                      {todo.title}
                    </Typography>{" "}
                  </Grid>
                </Grid>
                <Grid item xs={5}>
                  <Tooltip title="Delete task" placement="top">
                    <IconButton onClick={handleDelete} aria-label="delete">
                      <DeleteIcon color="secondary" fontSize="small" />
                    </IconButton>
                  </Tooltip>
                  <Tooltip title="Edit task" placement="top">
                    <IconButton onClick={toggleEdit} aria-label="edit">
                      <EditIcon fontSize="small" color="primary" />
                    </IconButton>
                  </Tooltip>
                  {!todo.isCompleted ? (
                    <Tooltip title="Complete task" placement="top">
                      <IconButton
                        onClick={handleComplete}
                        aria-label="complete"
                      >
                        <CheckCircleIcon color="primary" fontSize="small" />
                      </IconButton>
                    </Tooltip>
                  ) : (
                    ""
                  )}
                </Grid>
              </Grid>
            </CardContent>
          </Card>
        </>
      )}
    </div>
  );
};
export default Todo;
