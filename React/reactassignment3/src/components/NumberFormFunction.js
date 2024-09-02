import React, { useState } from 'react';

function NumberFormFunction() {
  const [num1, setNum1] = useState('');
  const [num2, setNum2] = useState('');
  const [results, setResults] = useState({ sum: '', difference: '', product: '', remainder: '' });

  const handleChange = (e) => {
    const { name, value } = e.target;
    if (name === 'num1') setNum1(value);
    if (name === 'num2') setNum2(value);
  };

  const calculate = (e) => {
    e.preventDefault();
    const n1 = parseFloat(num1);
    const n2 = parseFloat(num2);

    setResults({
      sum: n1 + n2,
      difference: n1 - n2,
      product: n1 * n2,
      remainder: n1 % n2
    });
  };

  return (
    <div>
      <form onSubmit={calculate}>
        <div>
          <label>Enter Number 1:</label>
          <input type="number" name="num1" value={num1} onChange={handleChange} />
        </div>
        <div>
          <label>Enter Number 2:</label>
          <input type="number" name="num2" value={num2} onChange={handleChange} />
        </div>
        <button type="submit">Calculate</button>
      </form>
      <div>
        <p>Sum: {results.sum}</p>
        <p>Difference: {results.difference}</p>
        <p>Product: {results.product}</p>
        <p>Remainder: {results.remainder}</p>
      </div>
    </div>
  );
}

export default NumberFormFunction;
