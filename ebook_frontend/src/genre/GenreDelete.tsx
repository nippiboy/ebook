import axios from "axios"
import { useParams } from "react-router-dom";
import ServerCommunication from "../ServerCommunication";
import { genreDTO } from "./genre.model";

export default function DeleteGenre() {
    var { id }: any = useParams();
    async function deleteGenre() {
        try {


            await axios.delete(`https://localhost:7267/genre/delete/${id}`)

        } catch (error) {
            console.log(error)
        }
    }


    return (
        <div>
            <div>Biztos</div>
            <button onClick={deleteGenre}>Igen</button>
        </div>
    )
}
