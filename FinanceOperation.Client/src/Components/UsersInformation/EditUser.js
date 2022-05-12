import React, {Component} from 'react';
import {Modal, Button, Row, Col, Form} from 'react-bootstrap';

export class EditUser extends Component{

    constructor(props){
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API + `users/${this.props.userid}`,{
            method: 'PATCH',
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
        .then((res)=>{res.json()},
        (error)=>
        {
            alert("Failed to update user")
        });
    }

    render(){
        return(
            <div className = 'container'>
            <Modal {...this.props} size = 'lg' aria-labelledby = "contained-modal-title-vcenter" centered>
                <Modal.Header closeButton>
                    <Modal.Title id = 'contained-modal-title-vcenter'>
                        Edit User
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Row>
                        <Col sm = {6}>
                            <Form onSubmit={this.handleSubmit}>
                            <Form.Group controlId = "UserId">
                                    <Form.Label>UserId</Form.Label>
                                    <Form.Control type = "text" name = "UserId" required
                                    disabled
                                    defaultValue={this.props.userid}
                                    placeholder='UserId'/>
                                </Form.Group>
                                <Form.Group controlId = "FirstName">
                                    <Form.Label>FirstName</Form.Label>
                                    <Form.Control type = "text" name = "FirstName" required
                                    defaultValue={this.props.firstname}
                                    placeholder='FirstName'/>
                                </Form.Group>
                                <Form.Group controlId = "SecondName">
                                    <Form.Label>SecondName</Form.Label>
                                    <Form.Control type = "text" name = "SecondName" required
                                    defaultValue={this.props.secondname}
                                    placeholder='SecondName'/>
                                </Form.Group>
                                <Form.Group controlId = "Email">
                                    <Form.Label>Email</Form.Label>
                                    <Form.Control type = "text" name = "Email" required
                                    defaultValue={this.props.email}
                                    placeholder='Email'/>
                                </Form.Group>
                                <Form.Group>
                                    <Button variant='primary' type ='submit'>
                                        Edit User
                                    </Button>
                                </Form.Group>
                            </Form>
                        </Col>
                    </Row>
                </Modal.Body>

                <Modal.Footer>
                    <Button variant = 'danger' onClick={this.props.onHide}>
                        Close
                    </Button>
                </Modal.Footer>
            </Modal>
            </div>
        );
    }

}