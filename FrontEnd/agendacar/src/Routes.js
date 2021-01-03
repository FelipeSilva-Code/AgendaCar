import {BrowserRouter, Switch, Route} from 'react-router-dom';
import React from 'react';
import AgendadosAtribuidosCliente from './Pages/Cliente/AgendadosCliente';
import AgendarNovoCliente from './Pages/Cliente/AgendarNovoCliente';
import Login from './Pages/Geral/Login';
import MenuCliente from './Pages/Cliente/MenuCliente';
import MenuFuncionario from './Pages/Funcionario/MenuFuncionario';
import Home from './Pages/Geral/Home';
import Pendentes from './Pages/Funcionario/AceitarAgendado';
import AgendadosFuncionario from './Pages/Funcionario/AgendadosFuncionario';
import Cadastrar from './Pages/Cliente/Cadastrar';
import InformacoesUsuario from './Pages/Cliente/InformacoesUsuario';
import AlterarSenha from './Pages/Cliente/AlterarSenha';
import AdicionarCarro from './Pages/Funcionario/AdicionarCarro';
import ListarCarros from './Pages/Funcionario/ListarCarros';
import VerInfoDoCarro from './Pages/Funcionario/VerInfoDoCarro';
import ProcuararConta from './Pages/Geral/EsqueceuSenha/ProcurarConta';
import EnviarCodigo from './Pages/Geral/EsqueceuSenha/EnviarCodigo';
import InserirCodigo from './Pages/Geral/EsqueceuSenha/InserirCodigo';
import NovaSenha from './Pages/Geral/EsqueceuSenha/NovaSenha';
import ProcurarUsuario from './Pages/Funcionario/ProcurarUsuuario';

export default function Routes() {
    return(
        <BrowserRouter>
          <Switch>
            <Route path="/" exact component={Home} />
            <Route path="/Login" exact component={Login} />
            <Route path="/ProcurarConta" exact component={ProcuararConta} />
            <Route path="/EnviarCodigo" exact component={EnviarCodigo} />
            <Route path="/InserirCodigo" exact component={InserirCodigo} />
            <Route path="/NovaSenha" exact component={NovaSenha} />
            <Route path="/Cadastrar" exact component={Cadastrar} />
            <Route path="/Cliente/Agendados" exact component={AgendadosAtribuidosCliente} />
            <Route path="/Cliente/Agendar" exact component={AgendarNovoCliente} />
            <Route path="/Cliente/Menu" exact component={MenuCliente} />
            <Route path="/Cliente/AlterarSenha" exact component={AlterarSenha} />
            <Route path="/Funcionario/agendados" exact component={AgendadosFuncionario} />
            <Route path="/Funcionario/Menu" exact component={MenuFuncionario} />
            <Route path="/Funcionario/Pendentes" exact component={Pendentes} />
            <Route path="/Funcionario/ListarCarros" exact component={ListarCarros} />
            <Route path="/Funcionario/VerInfoCarro" exact component={VerInfoDoCarro} />
            <Route path="/Funcionario/AdicionarCarro" exact component={AdicionarCarro} />
            <Route path="/Funcionario/ProcurarUsuario" exact component={ProcurarUsuario} />
            <Route path="/InformacoesUsuario" exact component={InformacoesUsuario} />
          </Switch>
        </BrowserRouter>
    )
}