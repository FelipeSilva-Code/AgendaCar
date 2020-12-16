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

export default function Routes() {
    return(
        <BrowserRouter>
          <Switch>
            <Route path="/" exact component={Home} />
            <Route path="/Login" exact component={Login} />
            <Route path="/Cadastrar" exact component={Cadastrar} />
            <Route path="/Cliente/Agendados" exact component={AgendadosAtribuidosCliente} />
            <Route path="/Cliente/Agendar" exact component={AgendarNovoCliente} />
            <Route path="/Cliente/Menu" exact component={MenuCliente} />
            <Route path="/Funcionario/agendados" exact component={AgendadosFuncionario} />
            <Route path="/Funcionario/Menu" exact component={MenuFuncionario} />
            <Route path="/Funcionario/Pendentes" exact component={Pendentes} />
            <Route path="/InformacoesUsuario" exact component={InformacoesUsuario} />
          </Switch>
        </BrowserRouter>
    )
}