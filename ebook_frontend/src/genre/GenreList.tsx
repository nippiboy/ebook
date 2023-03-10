import axios, { AxiosError, AxiosResponse } from "axios";
import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import Loading from "../utils/Loading";
import { genreDTO } from "./genre.model";

export default function GenresList() {
    const [genres, setGenres] = useState<genreDTO[]>();
    const [isLoading, setLoading] = useState(true);

    async function getGenres() {
        const userURL = "https://localhost:7267/genre"


        setLoading(true)

        try {
            await axios(userURL).then((response: AxiosResponse<genreDTO[]>) => {
                console.log(response.data)
                setGenres(response.data)
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

    useEffect(() => {
        getGenres()
    }, [])

    return (
        <>
            <h1 className="text-center" >Genres</h1>
            {isLoading ? <Loading /> :
                <div className="container">
                    <table className="table table-stripped">
                        <thead>
                           <tr><th>Name</th></tr>
                        </thead>
                        <tbody>
                            {teszt()}
                        </tbody>
                    </table>
                </div>
            }
        </>

    )


    function teszt() {
        return genres?.map(genre => {
            return (
                <tr key={genre.id}>
                    <td>
                        {genre.name}
                    </td>
                    <td>
                        <div className="btn btn-success">Edit</div>
                        <Link className="btn btn-danger" to={`genre/delete/${genre.id}`}>Delete</Link>
                    </td>

                </tr>
            )
        })
    }

}