import React, { useRef, useState } from 'react';

function NumberFormUncontrolled() {
  const num1Ref = useRef(null);
  const num2Ref = useRef(null);
  const [results, setResults] = useState({ sum: '', difference: '', product: '', remainder: '' });

  const calculate = (e) => {
    e.preventDefault();
    const num1 = parseFloat(num1Ref.current.value);
    const num2 = parseFloat(num2Ref.current.value);

    setResults({
      sum: num1 + num2,
      difference: num1 - num2,
      product: num1 * num2,
      remainder: num1 % num2
    });
  };

  return (
    <div>
      <form onSubmit={calculate}>
        <div>
          <label>Enter Number 1:</label>
          <input type="number" ref={num1Ref} />
        </div>
        <div>
          <label>Enter Number 2:</label>
          <input type="number" ref={num2Ref} />
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

export default NumberFormUncontrolled;
