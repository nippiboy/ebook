import axios, { AxiosError } from "axios"
import { useEffect, useState } from "react"
import Loading from "../utils/Loading"
import GenreCreate from "./GenreCreate"
import GenresList from "./GenreList"

export default function GenrePage() {

    

    return (
        <div className="me-auto">Genre Page
            <GenresList />
            <GenreCreate />
        </div>
    )

    function teszt()
    {
        return <div></div>
    }
}