import React from 'react';
import Menu from '../Menu';
import Footer from '../Footer';
import './Styles.css'

export default function ContainerTotal (props) {
    return(
        <>
            <Menu>{props.menu}</Menu>
            <div className="ContainerTotal">
            {props.children}
                
            </div>
            <Footer/>

        </>
    )
}