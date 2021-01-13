import React from 'react';
import Menu from '../MenuDeslogado';
import Footer from '../Footer';

export default function ContainerTotalDeslogado (props) {
    return(
        <>
            <Menu/>
                <div className="ContainerTotal">
                    {props.children}
                </div>
            <Footer/>

        </>
    )
}