import React from "react";
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';


const title = "Ebook"
const items = [{route: "/books", text: "Books"},
{route: "/profile", text: "Profile"},
{route: "/login", text: "Login"},
{route: "/genre", text: "Genre"}]


export default function MyNavbar() {
    return (
        <>
            <Navbar bg="light" variant="light" style={{marginBottom:"2rem"}}>
                    <Navbar.Brand href="/home">{title}</Navbar.Brand>
                    <Nav className="me-auto">
                        {renderNavItems()}
                    </Nav>
            </Navbar>

        </>
    );

    function renderNavItems()
    {
        return items.map(item => {
            return <Nav.Link href={item.route} key={item.route}>{item.text}</Nav.Link>
        })
    }

}
