import React, { Component } from 'react';
import ReactApexChart from 'react-apexcharts';

export class GetUserInOutCome extends Component{
    constructor(props){
        super(props);
        this.state = {
            incomes:[],
            incomesBanks:[], 
            outcomes:[],
            outcomesBanks:[]
    };
    this.getUserInOutCome();
    }

    getUserInOutCome(){
        fetch(process.env.REACT_APP_API + 'transactions/76abe599-dc8b-4495-bd36-26b5be8cab5e')
        .then(response=>response.json())
        .then(data=>{
            this.setState({incomes:data.incomes.map((income)=> income.summary)});
            this.setState({outcomes:data.outcomes.map((outcome)=> outcome.summary)});
            this.setState({incomesBanks:data.incomes.map((income)=> income.bankName)});
            this.setState({outcomesBanks:data.outcomes.map((outcome)=> outcome.bankName)});
        });
    }

    render()
    {
        return(
            <div className='pieWrapper'>
                <div className='pie1'>
                <h3>Income</h3>
            <ReactApexChart options={this.initLabels(this.state.incomesBanks)} series={this.state.incomes} type="donut" />
                </div>
                <div className='pie2'>
                <h3>Outcome</h3>
            <ReactApexChart options={this.initLabels(this.state.outcomesBanks)} series={this.state.outcomes} type="donut" />
                </div>
            </div>
        );
    } 

    initLabels(labels)
    {
      return  {
            chart: {
              type: 'donut',
            },
            plotOptions: {
                pie: {
                  donut: {
                    labels: {
                      show: true,
                      total: {
                        showAlways: true,
                        show: true
                      }
                    }
                  }
                }
              },
            labels: labels,
            responsive: [{
              breakpoint: 100,
              options: {
                  chart: {
                      width: 100,
                      height: 100
                },
                legend: {
                    position: 'bottom'
                }
            }
        }]
    };
    }
}


