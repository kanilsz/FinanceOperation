import React, {Component} from 'react';
import {Button, ButtonToolbar, Table} from 'react-bootstrap';
import {AddUser} from './AddUser';
import {EditUser} from './EditUser';

export class Users extends Component{

    constructor(props){
        super(props);
        this.state ={users:[], addModalShow: false, editModalShow: false}
        this.refreshList();
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

    deleteUser(userId){
        if(window.confirm('Are you sure to delete?'))
        {
            fetch(process.env.REACT_APP_API + 'users/' + userId, {
                method: 'DELETE',
                headers:{
                    'Accept':'application/json',
                    'Content-Type':'application/json'
                }
            });
        }
    }

    render(){
        const {users, userid, firstname, secondname, email} = this.state;
        let addModalClose=()=>this.setState({addModalShow:false});
        let editModalClose=()=>this.setState({editModalShow:false});

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
                            <td>
                                <ButtonToolbar>
                                    <Button className='mr-2' variant='info' 
                                    onClick={()=> this.setState({editModalShow:true, userid: user.id,
                                     firstname: user.firstName, secondname: user.secondName, email: user.email})}>
                                        Edit
                                    </Button>
                                    
                                    <Button className='mr-2' variant='danger' 
                                    onClick={()=> this.deleteUser(user.id)}>
                                        Delete
                                    </Button>

                                    <EditUser show = {this.state.editModalShow}
                                    onHide = {editModalClose}
                                    userid = {userid}
                                    firstname = {firstname}
                                    secondname = {secondname}
                                    email = {email}/>
                                </ButtonToolbar>
                            </td>
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