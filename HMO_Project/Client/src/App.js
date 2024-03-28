import {BrowserRouter, Route, Routes} from 'react-router-dom'
import PersonalDetailsList from './components/PersonalDetailsList';
import AddUpdateDetails from './components/AddUpdateDetails';
import CoronaSummery from './components/CoronaSummery'

function App() {

  return (<><div className="app">
   <BrowserRouter>
         <Routes>
           <Route path="/" element={<PersonalDetailsList />} />
           <Route path="/updateDetails" element={<AddUpdateDetails/>} />
           <Route path="/addDetails" element={<AddUpdateDetails/>} />
           <Route path="/coronaSummery" element={<CoronaSummery/>} />

         </Routes>
       </BrowserRouter> 
    </div>
    </>
  );
}

export default App;
