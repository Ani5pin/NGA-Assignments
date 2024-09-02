import './App.css';
import First from './components/First';
import Second from './components/Second';
import Third from './components/Third';
import Fourth from './components/Fourth';
import First1 from './components/First1';
import Second1 from './components/Second1';
import Third1 from './components/Third1';
import Fourth1 from './components/Fourth1';
import Student from './components/Student';
import Student1 from './components/Student1';
import Display from './components/Display';
function App() {
  const studentProps = {
    name: 'John Doe',
    address: '123 Main St',
    scores: [90, 85, 88],
  };
  const studentProps1 = {
    name: 'Aniket K Verma',
    address: '456 Elm St',
    scores: [92, 89, 84],
  };
  const handleHelloClick = () => {
    alert('Hello');
  };

  const handleByeClick = () => {
    alert('Bye');
  };

  return (
    <div className="App">
      <h1>Hello World</h1>
      <h2>Task 2</h2>
      <First />
    <Second />
    <Third />
    <Fourth />
    <h2>Task 3</h2>
    <First1 />
    <Second1 />
    <Third1 />
    <Fourth1 />
    <h2>Task 4</h2>
    <h3>using function</h3>
    <Student {...studentProps} />
    <h3>using class</h3>
    <Student1 {...studentProps1} />
    <h2>Task 5</h2>
    <Display name="Alice" address="789 Oak St" />
    <h2>Task 6</h2>
    <button onClick={handleHelloClick}>Say Hello</button>
      <button onClick={handleByeClick}>Say Bye</button>
    </div>
  );
}

export default App;
