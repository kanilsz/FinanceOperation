import React, {Component} from 'react';
import {Button, ButtonToolbar, Table} from 'react-bootstrap';
import {AddUser} from './AddUser';
import {EditUser} from './EditUser';
import './Style.scss';
import bankCardImg from "./Imgs/bankcard.png";
import discountCardImg from "./Imgs/discountcard.png"

export class GetUserCards extends Component{

    constructor(props){
        super(props);
        this.state ={bankCards:[], discountCards:[]}
        this.getCardsList();
    }

    getCardsList(){
        fetch(process.env.REACT_APP_API + 'users/76abe599-dc8b-4495-bd36-26b5be8cab5e/cards')
        .then(response=>response.json())
        .then(data=>{
            this.setState({bankCards:data.bankCards});
            this.setState({discountCards:data.discountCards});
        });
    }

    render(){
        const bankCards = this.state.bankCards;
        const discountCards = this.state.discountCards;
        return(
        <div className='cardswrapper'>
            <div className='bankсards'>
                <h3>Bank cards</h3>
                {bankCards.map(bankCard => 
                <p key = {bankCard.cardNumber}>
                    <img src={bankCardImg} className="img" alt = "Should be"/> 
                    {bankCard.cardNumber} Balance: {bankCard.balance}
                </p>)}
            </div>
           <div className='discountсards'>
            <h3>Discount cards</h3>
                {discountCards.map(discountCard => 
                <p key= {discountCard.cardNumber}>
                   <img src={discountCardImg} className="img" alt = "Should be"/> 
                   {discountCard.cardNumber} Balance: {discountCard.balance}
                </p>)}
           </div>
            
        </div>
        );
    }
}