import React from "react";
import ContainerTotal from "../../../Components/ContainerTotal"
import BlueContainer from "../../../Components/BlueContainer"

export default function AlterarSenha () {
    return (
      <ContainerTotal>
        <BlueContainer>
          <h3>Alterar Senha</h3>

        <div>
          <label>
            Senha Atual:<input className="form-control"></input>
          </label>

          <label>
            Nova Senha:<input className="form-control"></input>
          </label>

          <label>
            Repita a Senha<input className="form-control"></input>
          </label>
        </div>  

          <button className="btn btn-success">Alterar Senha</button>
        </BlueContainer>
      </ContainerTotal>
    );
}