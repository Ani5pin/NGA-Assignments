import React, { useContext } from 'react';
import { ColorContext } from './ColorContext';

const Comp1 = () => {
  const { setColor } = useContext(ColorContext);

  return (
    <div>
      <button onClick={() => setColor('lightblue')}>Set Color to Light Blue</button>
    </div>
  );
};

export default Comp1;
