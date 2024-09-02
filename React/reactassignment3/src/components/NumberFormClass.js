import React, { Component } from 'react';

class NumberFormClass extends Component {
  constructor(props) {
    super(props);
    this.state = {
      num1: '',
      num2: '',
      sum: '',
      difference: '',
      product: '',
      remainder: ''
    };
  }

  handleChange = (e) => {
    this.setState({ [e.target.name]: e.target.value });
  };

  calculate = (e) => {
    e.preventDefault();
    const num1 = parseFloat(this.state.num1);
    const num2 = parseFloat(this.state.num2);

    this.setState({
      sum: num1 + num2,
      difference: num1 - num2,
      product: num1 * num2,
      remainder: num1 % num2
    });
  };

  render() {
    return (
      <div>
        <form onSubmit={this.calculate}>
          <div>
            <label>Enter Number 1:</label>
            <input type="number" name="num1" value={this.state.num1} onChange={this.handleChange} />
          </div>
          <div>
            <label>Enter Number 2:</label>
            <input type="number" name="num2" value={this.state.num2} onChange={this.handleChange} />
          </div>
          <button type="submit">Calculate</button>
        </form>
        <div>
          <p>Sum: {this.state.sum}</p>
          <p>Difference: {this.state.difference}</p>
          <p>Product: {this.state.product}</p>
          <p>Remainder: {this.state.remainder}</p>
        </div>
      </div>
    );
  }
}

export default NumberFormClass;
