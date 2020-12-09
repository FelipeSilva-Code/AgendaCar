import React, { useState } from "react";
import { Link, useHistory } from "react-router-dom";
import ContainerTotal from "../../../Components/ContainerTotal";

export default function MenuFuncionario(props) {
  const [idUsuario] = useState(props.location.state.idUsuario);
  const [perfil] = useState(props.location.state.perfil);
  const [total] = useState({
    idUsuario,
    perfil
  })

  const history = useHistory();

  if (idUsuario === null || idUsuario === undefined) {
    history.push("/");
  }
  return (
    <ContainerTotal>
      <h3>Menu Funcionário</h3>

      <div>
        <h3>
        <Link to = {{
          pathname:`/Funcionario/agendados`,
          state: total,
        }}>Ver Meus Agendamentos</Link>
        </h3>
      </div>

      <div>
        <h3>
        <Link to = {{
          pathname:`/Funcionario/Pendentes`,
          state: total,
        }}>Ver Os Pendentes
        </Link>
        </h3>
      </div>
    </ContainerTotal>
  );
}
