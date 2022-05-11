import React, {Component} from 'react';
import {Modal, Button, Row, Col, Form} from 'react-bootstrap';

export class AddUser extends Component{

    constructor(props){
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(event){
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
            alert(result);
        },
        (error)=>
        {
            alert("Failed to create user")
        });
    }

    render(){
        return(
            <div className = 'container'>
            <Modal {...this.props} size = 'lg' aria-labelledby = "contained-modal-title-vcenter" centered>
                <Modal.Header closeButton>
                    <Modal.Title id = 'contained-modal-title-vcenter'>
                        Add User
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Row>
                        <Col sm = {6}>
                            <Form onSubmit={this.handleSubmit}>
                                <Form.Group controlId = "FirstName">
                                    <Form.Label>FirstName</Form.Label>
                                    <Form.Control type = "text" name = "FirstName" required placeholder='FirstName'/>
                                </Form.Group>
                                <Form.Group controlId = "SecondName">
                                    <Form.Label>SecondName</Form.Label>
                                    <Form.Control type = "text" name = "SecondName" required placeholder='SecondName'/>
                                </Form.Group>
                                <Form.Group controlId = "Email">
                                    <Form.Label>Email</Form.Label>
                                    <Form.Control type = "text" name = "Email" required placeholder='Email'/>
                                </Form.Group>
                                <Form.Group>
                                    <Button variant='primary' type ='submit'>
                                        Add User
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