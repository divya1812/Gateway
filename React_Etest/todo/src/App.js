import {Provider} from "react-redux";
import Store from "./store/store";
import Test from "./test";
const store = Store;


function App() {
  return (
    <Provider store = {store}> 
    <div>
     <Test/>
    </div>
    </Provider>
  );
}

export default App;
