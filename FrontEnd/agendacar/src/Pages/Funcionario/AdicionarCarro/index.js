import React from "react";
import "./styles.css";
import ContainerTotal from "../../../Components/ContainerTotal";
import { useState } from "react";
import { useHistory } from "react-router-dom";

export default function AdicionarCarro () {

    const history = useHistory();

    const [marca, setMarca] = useState();
    const [modelo, setModelo] = useState();
    const [anoVersao, setAnoVersao] = useState();
    const [anoModelo, setAnoModelo] = useState();
    const [cor, setCor] = useState();
    const [qtdCarros, setQtdCarros] = useState(1);

    return (
      <ContainerTotal>
        <div className="containerAdicionarCarro">
          <h3>Adicionar Carro</h3>

            <div className="containerInputsAdicionarCarro"> 
                <label>
                    Marca:
                    <input type="text" className="form-control" />
                </label>

                <label>
                    Modelo:
                    <input type="text" className="form-control" />
                </label>

                <label>
                    Cor:
                    <input type="text" className="form-control" />
                </label>

                <div className="divAnosAdicionarCarro">
                    <label>
                        Ano de fabricação:
                        <input type="number" className="form-control" />
                    </label>
                    
                    <label>
                        Ano da versão:
                        <input type="number" className="form-control" />
                    </label>
                </div>

                <label>
                    Qtd de carros:
                    <input value={qtdCarros} type="number" className="form-control" />
                </label>

            </div>

            <div className="divBtnsAdicionarCarro">
                <button className="btn btn-danger">Voltar</button>
                <button className="btn btn-success">Adicionar</button>
            </div>

        </div>
      </ContainerTotal>
    );
}