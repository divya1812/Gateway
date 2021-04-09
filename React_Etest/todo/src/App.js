import {Provider} from "react-redux";
import Store from "./store/store";
import Main from "./components/main";
const store = Store;


function App() {
  return (
    <Provider store = {store}> 
      <div style={{padding:"20px"}}>
        <Main/>
      </div>
    </Provider>
  );
}

export default App;
