import React, {Component} from 'react'
import logingImg from "../../logo.svg";

export class Login extends Component{

    constructor(props){
        super(props);
        this.login = this.login.bind(this);
    }

    login(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API + 'users',{
            method: 'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body: JSON.stringify({
                FirstName: event.target.FirstName.value,
                SecondName: event.target.SecondName.value,
                Email: event.target.Email.value,
                BankCards: null,
                DiscountCards: null
            })
        })
        .then(res=>res.json())
        .then((result)=>{
        },
        (error)=>
        {
            alert("Failed to login user")
        });
    }
    
    render(){
        return <div className='base-container' ref={this.props.containerRef}>
            <div className='header'>Login</div>
            <div className='content'>
                <div className='image'>
                    <img src={logingImg} alt = "Should be"/>
                </div>
                <div className='form'>
                    <div className='form-group'>
                        <label htmlFor='email'>Email</label>
                        <input type="text" name='email' placeholder='email'/>
                    </div>
                    <div className='form-group'>
                        <label htmlFor='password'>Password</label>
                        <input type="password" name='password' placeholder='password'/>
                    </div>
                </div>
            </div>
            <div className='footer'>
                <button type='button' className='btn' onSubmit={this.login}>Login</button>
            </div>
        </div>       
    }
}