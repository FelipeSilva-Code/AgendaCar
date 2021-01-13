import React from 'react'
import { Link, useHistory } from 'react-router-dom'
import './styles.css'

export default function MenuLogado (props) {

    const history = useHistory();

    const irParaTelaDeInfoDoUsuario = () => {
        history.push({pathname:"/informacoesUsuario", state: props.idUsuario})
    }

    const sair = () => {
        history.push("/")
    }
    return(
        <div className="Menu">
          <img className="logo" src="https://fontmeme.com/permalink/200919/5d47346918c190e6941f94b86f836ad4.png" alt="lovecraft-country-font" border="0"/>
           
           <div className="divMenuDireita">
            <button onClick={irParaTelaDeInfoDoUsuario} type="button" class="btn btn-danger">
                Ver Perfil
            </button>  

            <button onClick={sair} type="button" class="btn btn-danger">
                &nbsp; Sair &nbsp;
            </button>
      
           </div>
        </div>
    )
}