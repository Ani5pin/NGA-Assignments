import React, { Component } from 'react';

class Student1 extends Component
{
    render() {
        const { name, address, scores } = this.props;
        return (
          <div>
            <p>Name: {name}</p>
            <p>Address: {address}</p>
            <p>Scores: {scores.join(', ')}</p>
          </div>
        );
      }
    }
    
    export default Student1;
