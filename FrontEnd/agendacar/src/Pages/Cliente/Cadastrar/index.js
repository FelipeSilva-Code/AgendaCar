import React from "react";
import "./styles.css";
import ContainerTotal from "./../../../Components/ContainerTotal"
import {Link} from "react-router-dom"
import InputMask from "react-input-mask";

export default function Cadastrar () {
    return (
      <ContainerTotal>
        <div className="containerCadastrar">
          <h2>Cadastrar</h2>
        
            <div>
                <label>
                    Nome:
                    <input className="form-control" type="text" />
                </label>

                 <label>
                   Data de nascimento:
                    <input className="form-control" type="date" />
                </label>

              
            </div>
            
            <div>
                <label>
                    CNH:
                    <input className="form-control" type="text" />
                </label>

                  <label>
                    CPF:
                    <InputMask mask="999.999.999-99" className="form-control" type="text" />
                </label>
            </div>
         
           
           <div>
                <label>
                    Telefone:
                    <InputMask mask="(99) 9999-99999" className="form-control" type="text" />
                </label>

                <label>
                    E-mail:
                    <input className="form-control" type="text" />
                </label>
            </div>

            <div>
                 <label>
                    Senha:
                    <input className="form-control" type="password" />
                </label>

                 <label>
                   Confirme a senha:
                    <input className="form-control" type="password" />
                </label>
            </div>

            <div className="adicionarFotoCadastrar">
                <div className="divAdicionarFotoCadastrar">
                    <label className="labelAdicionarFotoCadastrar"> Adicione uma foto (opcional):
                        <div className="custom-file">
                            <input type="file" className="custom-file-input" id="inputGroupFile04" aria-describedby="inputGroupFileAddon04"/>
                            <label className="custom-file-label" htmlFor="inputGroupFile04">Escolher arquivo</label>
                        </div>
                    </label>
               </div>
                
            </div>

            <button className="btn btn-success">Cadastrar</button>

           <Link className="linkCadastrar" to="/login">Já tem uma contra? Logar</Link>
        </div>
      </ContainerTotal>
    );
}