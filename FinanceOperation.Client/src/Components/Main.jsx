import '../App.scss';

import React, {Component} from 'react'
import { Home } from './Home';
import { Users } from './UsersInformation/GetUsers';

import { BrowserRouter, Route, Switch } from 'react-router-dom';
import {UserCards} from './UsersInformation/UserCards';
import {GetUserInOutCome} from './UsersInformation/GetUserInOutCome';
import { Navigation } from './Navigation';
import { Index } from './Login/Index';

export class Main extends Component{
    constructor(props)
    {
      super(props);
      this.state ={ 
      }
    }
  
    render(){
        return (
        <BrowserRouter>
        <div className="Nav">
            <h3>
                Personal Finance Operations
            </h3>
        </div>
            <Navigation />
                <Switch>
                    <Route path='/' component={Home} exact />
                    <Route path='/login' component={Index}/>
                    <Route path='/user' component={Users} />
                    <Route path='/usercards' component={UserCards} />
                    <Route path='/userinoutcome' component={GetUserInOutCome} />
                </Switch>
        </BrowserRouter> 
    );
    }
}