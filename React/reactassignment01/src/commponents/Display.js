// src/components/Display.js
import React, { useState } from 'react';

function Display({ name: initialName, address: initialAddress }) {
  const [name, setName] = useState(initialName);
  const [address, setAddress] = useState(initialAddress);

  return (
    <div>
      <input
        type="text"
        value={name}
        onChange={(e) => setName(e.target.value)}
      />
      <input
        type="text"
        value={address}
        onChange={(e) => setAddress(e.target.value)}
      />
      <p>Name: {name}</p>
      <p>Address: {address}</p>
    </div>
  );
}

export default Display;
