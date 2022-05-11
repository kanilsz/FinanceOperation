import './App.css';

import { Home } from './Components/Home';
import { Users } from './Components/UsersInformation/Users';
import { Navigation } from './Components/Navigation';

import { BrowserRouter, Route, Switch } from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <h3>
          Personal Finance Operation
        </h3>
        <Navigation />
        <Switch>
          <Route path='/' component={Home} exact />
          <Route path='/user' component={Users} />
        </Switch>
      </div>
    </BrowserRouter>
  );
}

export default App;
