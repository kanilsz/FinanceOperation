import './App.scss';

import React, {Component} from 'react'
import { Home } from './Components/Home';
import { Users } from './Components/UsersInformation/GetUsers';
import { Navigation } from './Components/Navigation';

import { BrowserRouter, Route, Switch } from 'react-router-dom';
import { Login , Register} from './Components/Login/Index';

class App extends Component{

  constructor(props)
  {
    super(props);
    this.state ={ 
      isLoggingActive: true
    }
  }

  changeState(){
    const {isLoggingActive} = this.state;
    if(isLoggingActive){
      this.RightSide.classList.remove("right");
      this.RightSide.classList.add("left");
    } else{
      this.RightSide.classList.remove("left");
      this.RightSide.classList.add("right");
    }

    this.setState((prevState)=>({isLoggingActive: !prevState.isLoggingActive}));
  }

  render(){
    const{isLoggingActive} = this.state;
    const current = isLoggingActive ? "Register":"Login";
   
    return(
      <div className="App">
        <div className='login'>
          <div className='container'>
            {isLoggingActive && <Login containerRef={(ref)=> this.current = ref} /> }
            {!isLoggingActive && <Register containerRef={(ref)=> this.current = ref}/>}
          </div>
          <RightSide current={current} containerRef={ref => this.RightSide = ref} onClick={this.changeState.bind(this)}/>
        </div>
      </div>
    );
  }
}

const RightSide = props =>{
  return <div className='right-side' ref={props.containerRef} onClick={props.onClick}> 
      <div className='text'>
        {props.current}
    </div>
  </div>
}
// {/* <BrowserRouter>
//       <div className="App">
//         <h3>
//           Personal Finance Operation
//         </h3>
//         <Login/>
//         <Navigation />
//         <Switch>
//           <Route path='/' component={Home} exact />
//           <Route path='/user' component={Users} />
//         </Switch>
//       </div>
//     </BrowserRouter> */}
export default App;
