import React, {Component} from 'react';
import {Button, ButtonToolbar, Table} from 'react-bootstrap';
import {AddUser} from './AddUser';

export class Users extends Component{

    constructor(props){
        super(props);
        this.state ={users:[], addModalShow: false}
    }

    refreshList(){
        fetch(process.env.REACT_APP_API + 'users')
        .then(response=>response.json())
        .then(data=>{
            this.setState({users:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate(){
        this.refreshList();
    }

    render(){
        const {users} = this.state;
        let addModalClose=()=>this.setState({addModalShow:false});
        return(
        <div >
            <Table className='mt-4' striped bordered hover size = 'sm'>
                <thead>
                    <tr>
                    <th>UserId</th>
                    <th>FirstName</th>
                    <th>SecondName</th>
                    <th>Email</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map((user)=>
                        <tr key = {user.id}>
                            <td> {user.id} </td>
                            <td> {user.firstName} </td>
                            <td> {user.secondName} </td>
                            <td> {user.email} </td>
                            <td> Edit/Delete </td>
                        </tr>)}
                </tbody>
            </Table>

            <ButtonToolbar>
                <Button variant = 'primary' onClick = {()=>this.setState({addModalShow:true})}>
                    Add User
                </Button>

                <AddUser show = {this.state.addModalShow} onHide = {addModalClose}/>
            </ButtonToolbar>
        </div>  
        );
    }
}