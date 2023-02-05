import React, {Component} from 'react'
import logingImg from "../../logo.svg";
import bcrypt from 'bcryptjs'

const salt = bcrypt.genSaltSync(10)
export class Register extends Component{

    constructor(props){
        super(props);
        this.register = this.register.bind(this);
        this.handleChange = this.handleChange.bind(this);

        this.state = {
            FirstName: null,
            SecondName: null,
            Email: null,
            Password: null
        }
    }

    handleChange({ target }) {
        this.setState({
          [target.name]: target.value
        });
      }

    register(event){
        event.preventDefault();

        fetch(process.env.REACT_APP_API + 'identity',{
            method: 'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body: JSON.stringify({
                FirstName: this.state.FirstName,
                SecondName: this.state.SecondName,
                Email: this.state.Email,
                Password: bcrypt.hashSync(this.state.Password, salt),
            })
        })
        .then(res=>res.json())
        .then((result)=>{
        },
        (error)=>
        {
            alert("Failed to register user")
        });
    }

    render(){
        return <div className='base-container' ref={this.props.containerRef}>
            <div className='header'>Register</div>
            <div className='content'>
                <div className='image'>
                    <img src={logingImg} alt = "Should be "/>
                </div>
                <div className='form'>
                    <div className='form-group'>
                        <label htmlFor='Email'>Email</label>
                        <input type="email" name='Email' placeholder='Email' onChange={ this.handleChange }/>
                    </div>
                    <div className='form-group'>
                        <label htmlFor='FirstName'>First Name</label>
                        <input type="text" name='FirstName' placeholder='FirstName' onChange={ this.handleChange }/>
                    </div>
                    <div className='form-group'>
                        <label htmlFor='SecondName'>Second Name</label>
                        <input type="text" name='SecondName' placeholder='SecondName' onChange={ this.handleChange }/>
                    </div>
                    <div className='form-group'>
                        <label htmlFor='Password'>Password</label>
                        <input type="password" name='Password' placeholder='Password' onChange={ this.handleChange }/>
                    </div>
                </div>
            </div>
            <div className='footer'>
                <button type='button' className='btn' onClick={this.register}>Register</button>
            </div>
        </div>
        
    }
}