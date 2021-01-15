import React from "react";
import "./styles.css";
import ContainerTotal from "../../../Components/ContainerTotalLogado";
import { useState } from "react";
import { useHistory } from "react-router-dom";
import TestDriveApi from "../../../Services/TestDriverApi";
import {toast, ToastContainer} from "react-toastify"

const api = new TestDriveApi();

export default function AdicionarCarro (props) {

    const history = useHistory();

    const [idUsuario, setIdUsuario] = useState(props.location.state);
    
    const [marca, setMarca] = useState("");
    const [modelo, setModelo] = useState("");
    const [anoVersao, setAnoVersao] = useState();
    const [anoFabricacao, setAnoFabricacao] = useState();
    const [cor, setCor] = useState("");
    const [qtdCarros, setQtdCarros] = useState(1);

    const adicionarCarro = async () => {

        try {
            const request = {
              Marca: marca,
              Modelo: modelo,
              Cor: cor,
              AnoFabricacao: anoFabricacao,
              AnoVersao: anoVersao,
              QtdCarros: qtdCarros,
            };

            await api.adicionarCarro(request);   

            limparInputs();
            
            toast.success("Carro adicionado com sucesso!")
        } catch (e) {
            toast.error(e.response.data.mensagem);
        }
    }

    const limparInputs = () => {
        setMarca("");
        setModelo("");
        setCor("");
        setAnoFabricacao(0);
        setAnoVersao(0);
        setQtdCarros(1);
    }

    const voltar = () => {
        history.goBack();
    }
    return (
      <ContainerTotal idUsuario={idUsuario} perfil="Funcionario">
          <ToastContainer/>
        <div className="containerAdicionarCarro">
          <h3>Adicionar Carro</h3>

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
                <button onClick={adicionarCarro} className="btn btn-success">Adicionar</button>
            </div>

        </div>
      </ContainerTotal>
    );
}