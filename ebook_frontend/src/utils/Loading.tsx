import React, { ReactComponentElement, ReactElement } from "react"
import loadingGif from '../Loading_icon.gif'

export default function Loading() {
    
    return (
        <>
            <img src={loadingGif} alt="loadingGif" style={{maxWidth:"100px", maxHeight:"100px"}}/>
        </>
    )
}
