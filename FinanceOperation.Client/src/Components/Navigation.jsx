import React, { Component } from 'react';
import { NavLink } from 'react-router-dom';
import { Navbar, Nav } from 'react-bootstrap';

export class Navigation extends Component {

    render() {
        return (
            <Navbar bg='success' expand='lg'>
                <Navbar.Toggle aria-controls='basic-navbar-nav' />
                <Navbar.Collapse id='basic-navbar-nav'>
                    <Nav>
                        <NavLink className='d-inline p-2 bg-success text-white ' to='/'>
                            Home
                        </NavLink>
                        <NavLink className='d-inline p-2 bg-success text-white ' to='/user'>
                            Users
                        </NavLink>
                        <NavLink className='d-inline p-2 bg-success text-white ' to='/usercards'>
                            User cards
                        </NavLink>
                        <NavLink className='d-inline p-2 bg-success text-white ' to='/userinoutcome'>
                            User Income & Outcome
                        </NavLink>
                        <NavLink className='d-inline p-2 bg-success text-white ' to='/login'>
                            Login
                        </NavLink>
                    </Nav>
                </Navbar.Collapse>
            </Navbar>
        );
    }
}