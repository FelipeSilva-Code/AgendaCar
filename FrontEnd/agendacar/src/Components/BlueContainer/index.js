import React from 'react'
import './Style.css'

export default function BlueContainer (props) {
    return(
        <div className="blueContainer">
           {props.children}
        </div>
    )
}