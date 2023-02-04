import React, {Component} from 'react';
import './Style.scss';
import bankCardImg from "./Imgs/bankcard.png";
import discountCardImg from "./Imgs/discountcard.png"
import {Button} from 'react-bootstrap';

export class UserCards extends Component{

    constructor(props){
        super(props);
        this.state ={bankCards:[], discountCards:[], userId: "76abe599-dc8b-4495-bd36-26b5be8cab5e", addModalShow: false}
        this.addUserBankCard = this.addUserBankCard.bind(this);
        this.addUserDiscountCard = this.addUserDiscountCard.bind(this);
        this.getCardsList();
    }

    getCardsList(){
        fetch(process.env.REACT_APP_API + `users/${this.state.userId}/cards`)
        .then(response=>response.json())
        .then(data=>{
            this.setState({bankCards:data.bankCards});
            this.setState({discountCards:data.discountCards});
        });
    }

    deleteUserBankCard(userId, cardNumber){
        if(window.confirm('Are you sure to delete?'))
        {
            fetch(process.env.REACT_APP_API + 'users/' + userId + '/bankCards/' + cardNumber, {
                method: 'DELETE',
                headers:{
                    'Accept':'application/json',
                    'Content-Type':'application/json'
                }
            });
            this.getCardsList();
            window.location.reload();
        }
    }

    deleteUserDiscountCard(userId, cardNumber){
        if(window.confirm('Are you sure to delete?'))
        {
            fetch(process.env.REACT_APP_API + 'users/' + userId + '/discountCards/' + cardNumber, {
                method: 'DELETE',
                headers:{
                    'Accept':'application/json',
                    'Content-Type':'application/json'
                }
            });
            this.getCardsList();
            window.location.reload();
        }
    }

    addUserBankCard(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API + `users/${this.state.userId}/bankCards` ,{
            method: 'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body: JSON.stringify({
                CardNumber: event.target.CardNumber.value,
                Balance: event.target.Balance.value,
            })
        })
        .then(res=>res.json())
        .then((result)=>{
        },
        (error)=>
        {
            alert("Failed to create bank card")
        });
        this.getCardsList();
    }

    addUserDiscountCard(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API + `users/${this.state.userId}/discountCards` ,{
            method: 'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body: JSON.stringify({
                CardNumber: event.target.CardNumber.value,
                Balance: event.target.Balance.value,
            })
        })
        .then(res=>res.json())
        .then((result)=>{
        },
        (error)=>
        {
            alert("Failed to create discount card")
        });
        this.getCardsList();
    }
    
    render(){
        const bankCards = this.state.bankCards;
        const discountCards = this.state.discountCards;
        let addModalClose=()=>this.setState({addModalShow:false});
        return(
        <div className='cardswrapper'>
            <div className='bankсards'>
                <h3>Bank cards</h3>
                {bankCards.map(bankCard => 
                <p key = {bankCard.cardNumber}>
                    <img src={bankCardImg} className="img" alt = "Should be"/> 
                    {bankCard.cardNumber} Balance: {bankCard.balance}
                    <Button className='mr-2' variant='danger' 
                            onClick={()=> this.deleteUserBankCard(this.state.userId, bankCard.cardNumber)}>
                                Remove
                    </Button>
                </p>)}
        </div>
            
        <div className='discountсards'>
            <h3>Discount cards</h3>
                {discountCards.map(discountCard => 
                <p key= {discountCard.cardNumber}>
                   <img src={discountCardImg} className="img" alt = "Should be"/> 
                   {discountCard.cardNumber} Balance: {discountCard.balance}
                   <Button className='mr-2' variant='danger' 
                            onClick={()=> this.deleteUserDiscountCard(this.state.userId, discountCard.cardNumber)}>
                                Remove
                    </Button>

                </p>)}     
           </div>
        </div>);
    }
}