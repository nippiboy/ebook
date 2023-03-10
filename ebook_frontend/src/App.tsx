import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios, { AxiosError, AxiosResponse } from 'axios';
import loadingGif from './Loading_icon.gif'
import Navbar from './navbar/Navbar';
import Loading from './utils/Loading';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import routes from './navbar/routeConfig';

function App() {


  const [isLoading, setLoading] = useState(false)

  interface userDTO {
    userName: string,
    creditAmount: number,
    userEmail: string
  }

  async function teszt() {

    const userURL = "https://localhost:7267/user/all"

    /*await axios.get(userURL)
    .then((response: AxiosResponse<number[]>) => {
      console.log(response.status)
      console.log(response.data);
    })*/

    setLoading(true)

    try {
      await axios(userURL).then((response) => {
        console.log(response.data)
        setLoading(false)
      })

    }
    catch (error) {
      const serverError = error as AxiosError
      console.log(serverError.response?.status)
      if (serverError.response?.status === 500) {
        console.log(serverError.response?.data)
      }
      setLoading(false)
    }


  }

  return (
    <BrowserRouter>
      <div className="App">
        <header className="App-header">
        </header>
        <Navbar />
        

        <Switch>
          {routes.map(route => {
            return <Route key={route.path} path={route.path} exact={route.exact}>
              <route.component />
            </Route>
          })}

        </Switch>

      </div>
    </BrowserRouter>
  );
}

export default App;
