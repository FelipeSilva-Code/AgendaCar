import React from "react";
import { useState } from "react";
import { useHistory } from "react-router-dom";
import ContainerTotal from "../../../Components/ContainerTotal"


export default function VerInfoDoCarro (props) {

    const [idCarro, setIdCarro] = useState(props.location.state);
   
    const [marca, setMarca] = useState("");
    const [modelo, setModelo] = useState("");
    const [anoVersao, setAnoVersao] = useState();
    const [anoFabricacao, setAnoFabricacao] = useState();
    const [cor, setCor] = useState("");
    const [qtdCarros, setQtdCarros] = useState(1);

    const history = useHistory();

    console.log(idCarro);

    const voltar = () => {
        const r = window.confirm("Todas as alterações não salvas serão perdidas");

        if(r === true)
            history.goBack();
    }

    return(
        <ContainerTotal>
             <div className="containerAdicionarCarro">
          <h3>Alterar Informações</h3>

            <div className="containerInputsAdicionarCarro"> 
                <label>
                    Marca:
                    <input value={marca} onChange={e => setMarca(e.target.value)} type="text" className="form-control" />
                </label>

                <label>
                    Modelo:
                    <input value={modelo} onChange={e => setModelo(e.target.value)} type="text" className="form-control" />
                </label>

                <label>
                    Cor:
                    <input value={cor} onChange={e => setCor(e.target.value)} type="text" className="form-control" />
                </label>

                <div className="divAnosAdicionarCarro">
                    <label>
                        Ano de fabricação:
                        <input value={anoFabricacao} onChange={e => setAnoFabricacao(e.target.value)} type="number" className="form-control" />
                    </label>
                    
                    <label>
                        Ano da versão:
                        <input value={anoVersao} onChange={e => setAnoVersao(e.target.value)} type="number" className="form-control" />
                    </label>
                </div>

                <label>
                    Qtd de carros:
                    <input value={qtdCarros} onChange={e => setQtdCarros(e.target.value)} value={qtdCarros} min="1" type="number" className="form-control" />
                </label>

            </div>

            <div className="divBtnsAdicionarCarro">
                <button onClick={voltar} className="btn btn-danger">Voltar</button>
                <button  className="btn btn-success">Alterar</button>
            </div>

        </div>
        </ContainerTotal>
    )
}