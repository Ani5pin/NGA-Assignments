import React, { useContext } from 'react';
import { ColorContext } from './ColorContext';

const Comp3 = () => {
  const { setColor } = useContext(ColorContext);

  return (
    <div>
      <button onClick={() => setColor('lightbrown')}>Set Color to Light Brown</button>
    </div>
  );
};

export default Comp3;
