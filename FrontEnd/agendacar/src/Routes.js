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

export default function Routes() {
    return(
        <BrowserRouter>
          <Switch>
            <Route path="/" exact component={Home} />
            <Route path="/Login" exact component={Login} />
            <Route path="/Cliente/Agendados/:id" exact component={AgendadosAtribuidosCliente} />
            <Route path="/Cliente/Agendar/:id" exact component={AgendarNovoCliente} />
            <Route path="/Cliente/Menu/:id" exact component={MenuCliente} />
            <Route path="/Funcionario/agendados/:id" exact component={AgendadosFuncionario} />
            <Route path="/Funcionario/Menu/:id" exact component={MenuFuncionario} />
            <Route path="/Funcionario/Pendentes/:id" exact component={Pendentes} />
          </Switch>
        </BrowserRouter>
    )
}