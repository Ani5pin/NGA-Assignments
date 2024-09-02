import React from 'react';

function Student({ name, address, scores }) {
  return (
    <div>
      <p>Name: {name}</p>
      <p>Address: {address}</p>
      <p>Scores: {scores.join(', ')}</p>
    </div>
  );
}

export default Student;