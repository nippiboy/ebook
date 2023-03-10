import DeleteGenre from "../genre/GenreDelete";
import GenrePage from "../genre/GenrePage";
import HomePage from "../home/Home";
import LoginPage from "../login/Login";

const routes = [
    {path: '/genre', component: GenrePage, exact: true},
    {path: '/genre/delete/:id(\\d+)', component: DeleteGenre},

    {path: '/login', component: LoginPage, exact: true},
    {path: '/', component: HomePage}
]

export default routes;