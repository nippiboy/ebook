import axios, { Axios, AxiosResponse } from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

export default function ServerCommunication<TCreation, TRead>(props: Iprops<TCreation, TRead>)
{
    const { id } : any = useParams();
    const [entity, setEntity] = useState<TCreation>();

    useEffect(()=>
    {
        axios.get(`${props.url}/${id}`).then(
            (response: AxiosResponse<TRead>) => {
                setEntity(props.transform(response.data))
            }
        )
    },[id]);

}

interface Iprops<TCreation, TRead>
{
    url: string;
    entityName: string;
    indexURL: string;
    transform(entity: TRead): TCreation
}