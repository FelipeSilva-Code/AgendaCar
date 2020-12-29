import React from "react";
import "./styles.css";
import ContainerTotal from "../../../../Components/ContainerTotal";

export default function NovaSenha () {
    return(
        <ContainerTotal>
            <div className="containerNovaSenha">
                <div className="divAlterarSenhaNova">
                    <h4>Alterar Senha</h4>
                </div>

                <div className="divAdicionarNovaSenha">
                    <label>Nova Senha
                        <input type="password" className="form-control" />
                    </label>

                     <label>Repita a Senha
                        <input type="password" className="form-control" />
                    </label>
                </div>
                
                <div className="divBtnsNovaSenha">
                    <button className="btn btn-success">Confirmar</button>
                    <button className="btn btn-danger">Cancelar</button>
                </div>
            </div>
        </ContainerTotal>
    )
}