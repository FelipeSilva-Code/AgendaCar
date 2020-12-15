import React, { useState } from "react";
import "./styles.css";
import ContainerTotal from "./../../../Components/ContainerTotal"
import {Link} from "react-router-dom"
import InputMask from "react-input-mask";
import TestDriveApi from "../../../Services/TestDriverApi";
import {toast, ToastContainer} from "react-toastify"

const api = new TestDriveApi();

export default function Cadastrar () {

    const [nome, setNome] = useState("");
    const [dataNascimento, setDataNascimento] = useState();
    const [cnh, setCnh] = useState("");
    const [cpf, setCpf] = useState("");
    const [telefone, setTelefone] = useState("");
    const [email, setEmail] = useState("");
    const [senha1, setSenha1] = useState("");
    const [senha2, setSenha2] = useState("");
    const [foto, setFoto] = useState(null);

    const cadastrar = async () => {
        try {

            toast.success("olaaa")

             const req = {
               Nome: nome,
               DataNascimento: dataNascimento,
               CNH: cnh,
               CPF: cpf,
               Telefone: telefone,
               Email: email,
               Senha1: senha1,
               Senha2: senha2,
               ImagemUsuario: foto,
             };

             console.log(req);

              await api.cadastrarCliente(req);

              toast.success("Cadastrado com sucesso")
            
        } catch (e) {

            toast.error(e.response.data.mensagem);
            console.log(e.response.data.mensagem)
            
        }
    }
    return (
      <ContainerTotal>
          <ToastContainer/>
        <div className="containerCadastrar">
          <h2>Cadastrar</h2>
        
            <div>
                <label>
                    Nome:
                    <input onChange={e => setNome(e.target.value)} className="form-control" type="text" />
                </label>

                 <label>
                   Data de nascimento:
                    <input onChange={e => setDataNascimento(e.target.value)} className="form-control" type="date" />
                </label>

              
            </div>
            
            <div>
                <label>
                    CNH:
                    <InputMask mask="99999999999" onChange={e => setCnh(e.target.value)} className="form-control" type="text" />
                </label>

                  <label>
                    CPF:
                    <InputMask onChange={e => setCpf(e.target.value)} mask="999.999.999-99" className="form-control" type="text" />
                </label>
            </div>
         
           
           <div>
                <label>
                    Telefone:
                    <InputMask onChange={e => setTelefone(e.target.value)} mask="(99) 9999-99999" className="form-control" type="text" />
                </label>

                <label>
                    E-mail:
                    <input onChange={e => setEmail(e.target.value)} className="form-control" type="text" />
                </label>
            </div>

            <div>
                 <label>
                    Senha:
                    <input onChange={e => setSenha1(e.target.value)} className="form-control" type="password" />
                </label>

                 <label>
                   Confirme a senha:
                    <input onChange={e => setSenha2(e.target.value)} className="form-control" type="password" />
                </label>
            </div>

            <div className="adicionarFotoCadastrar">
                <div className="divAdicionarFotoCadastrar">
                    <label className="labelAdicionarFotoCadastrar"> Adicione uma foto (opcional):
                        <div className="custom-file">
                            <input onChange={e => setFoto(e.target.files[0])} type="file" className="custom-file-input" id="inputGroupFile04" aria-describedby="inputGroupFileAddon04"/>
                            <label className="custom-file-label" htmlFor="inputGroupFile04">Escolher arquivo</label>
                        </div>
                    </label>
               </div>
                
            </div>

            <button onClick={cadastrar} className="btn btn-success">Cadastrar</button>

           <Link className="linkCadastrar" to="/login">Já tem uma contra? Entrar</Link>
        </div>
      </ContainerTotal>
    );
}