import {  useDispatch } from "react-redux";
import {addItem, deleteItem, editItem, updateStatus} from './store/actions/action'


const Test = () => {
    const dispatch = useDispatch();

    const addtodo = () =>{
      dispatch(addItem("todo1"))
    }
    const deletetodo = () =>{
      dispatch(deleteItem(1))
    }
    const edittodo = () =>{
      dispatch(editItem(1,"hello world"))
    }
    const statuschange = () =>{
      dispatch(updateStatus(1))
    }
    return (
        <div>
              <button onClick={addtodo}>click</button>
              <button onClick={deletetodo}>deleteme</button>
              <button onClick={edittodo}>edit</button>
              <button onClick={statuschange}>state</button>
        </div>
    )
}

export default Test