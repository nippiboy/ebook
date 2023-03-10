import axios from "axios"
import { useRef } from "react"
import { genreCreationDTO } from "./genre.model"

export default function GenreCreate() {

    const genreNameRef = useRef<HTMLInputElement>(null)

    return (
        <>
            <form onSubmit={submitHandler}>
                <label>Genre name</label>
                <input type="text" ref={genreNameRef}></input>
                <button type="button" onClick={submitHandler}>Ok</button>
            </form>
        </>
    )

    function submitHandler()
    {
        const genre: genreCreationDTO = {name: String(genreNameRef.current?.value)}
        console.log(genre)
        axios.post("https://localhost:7267/genre",genre).then((response)=>
        {
            console.log(response.data)
        })
    }
}