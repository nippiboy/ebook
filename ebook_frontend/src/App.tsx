import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios, { AxiosResponse } from 'axios';

function App() {

  async function teszt()
  {

    const userURL = "https://localhost:7267/user/all"

    axios.get(userURL)
    .then((response: AxiosResponse<number[]>) => {
      console.log(response.data);
    })
  }

  return (
    <div className="App">
      <header className="App-header">
        <div className='container'>
          <h1>
            Hello World!
          </h1>
          <button onClick={teszt}>Click me</button>
        </div>
      </header>
    </div>
  );
}

export default App;
