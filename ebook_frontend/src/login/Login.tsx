import React, { useRef } from "react";
import { Card } from "react-bootstrap";


export default function LoginPage() {

    const emailRef = useRef<HTMLInputElement>(null);
    const passwordRef = useRef<HTMLInputElement>(null);

    return (
        <div className="d-flex align-items-center justify-content-center">
            <Card style={{ width: "30rem" }}>
                <Card.Body>
                    {loginBody()}
                </Card.Body>
            </Card>
        </div>

    );

    function handleSubmit()
    {
        console.log(emailRef.current?.value)
        console.log(passwordRef.current?.value)
    }

    function loginBody() {
        return (
            <div className="Auth-form-container">
                <form className="Auth-form" onSubmit={handleSubmit}>
                    <div className="Auth-form-content">
                        <h3 className="Auth-form-title">Login</h3>
                        <div className="form-group mt-3">
                            <label>Email address</label>
                            <input
                                type="email"
                                className="form-control mt-1"
                                placeholder="Enter email"
                                ref={emailRef}
                            />
                        </div>
                        <div className="form-group mt-3">
                            <label>Password</label>
                            <input
                                type="password"
                                className="form-control mt-1"
                                placeholder="Enter password"
                                ref={passwordRef}
                            />
                        </div>
                        <div className="d-grid gap-2 mt-3">
                            <button type="submit" className="btn btn-primary">
                                Login
                            </button>
                        </div>
                        <div className="container">
                            <div className="row">
                                <div className="col-sm">
                                    <p className="forgot-password text-start mt-2">
                                        Forgot <a href="#">password?</a>
                                    </p>

                                </div>
                                <div className="col-sm">
                                    <p className="text-end mt-2"><a href="#"> Need account?</a></p>

                                </div>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        )
    }

}


/*
<div className="Auth-form-container">
        <form className="Auth-form">
          <div className="Auth-form-content">
            <h3 className="Auth-form-title">Login</h3>
            <div className="form-group mt-3">
              <label>Email address</label>
              <input
                type="email"
                className="form-control mt-1"
                placeholder="Enter email"
              />
            </div>
            <div className="form-group mt-3">
              <label>Password</label>
              <input
                type="password"
                className="form-control mt-1"
                placeholder="Enter password"
              />
            </div>
            <div className="d-grid gap-2 mt-3">
              <button type="submit" className="btn btn-primary">
                Submit
              </button>
            </div>
            <p className="forgot-password text-right mt-2">
              Forgot <a href="#">password?</a>
            </p>
          </div>
        </form>
      </div>*/