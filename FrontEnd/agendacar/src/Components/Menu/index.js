import React from 'react'
import { Link } from 'react-router-dom'
import './styles.css'

export default function Menu () {
    return(
        <div className="Menu">
       <Link to="/"> <img className="logo" src="https://fontmeme.com/permalink/200919/5d47346918c190e6941f94b86f836ad4.png" alt="lovecraft-country-font" border="0"/></Link>
        </div>
    )
}