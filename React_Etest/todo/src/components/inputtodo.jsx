import React from "react";
import { useDispatch } from "react-redux";
import { addItem } from "../store/actions/action";
import TextField from "@material-ui/core/TextField";
import { Button } from "@material-ui/core";
import SendIcon from "@material-ui/icons/Send";

const Inputtodo = () => {
  const dispatch = useDispatch();
  const [title, setValue] = React.useState("");

  const handleChange = (event) => {
    setValue(event.target.value);
  };

  const addtodo = () => {
    dispatch(addItem(title));
  };

  return (
    <div
      style={{
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        width: "400px",
      }}
    >
      <TextField
        id="outlined-textarea"
        label="Add Task"
        placeholder="Add Task"
        multiline
        fullWidth={true}
        variant="outlined"
        value={title}
        onChange={handleChange}
      />
      <Button onClick={addtodo}>
        <SendIcon color="primary" />
      </Button>
    </div>
  );
};

export default Inputtodo;
