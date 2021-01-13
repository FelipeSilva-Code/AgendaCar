
/*
CREATE DATABASE db_test_drive;

USE db_test_drive;

CREATE TABLE tb_login (
  Id_login INT PRIMARY KEY AUTO_INCREMENT,
  ds_email         varchar(50),
  ds_senha         varchar(50),
  ds_perfil        varchar(50),
  dt_ultimo_login  datetime
);

create table tb_funcionario (
   id_funcionario int primary key auto_increment,
   id_login           		 int,
   nm_funcionario            varchar(100),
   ds_carteira_trabalho      varchar(14),
   ds_cpf                    varchar(14),
   ds_telefone               varchar(15),
   dt_nascimento             datetime,
   ds_foto                   varchar(200),
   foreign key(id_login) references tb_login(id_login) on delete cascade
);

create table tb_cliente (
   id_cliente int primary key auto_increment,
   id_login                int,
   nm_cliente              varchar(100),
   ds_cnh                  varchar(14),                                                                                          
   ds_cpf                  varchar(14),
   ds_telefone             varchar(15),
   dt_nascimento           datetime,
   ds_foto                 varchar(200),
   foreign key(id_login) references tb_login(id_login) on delete cascade
);

create table tb_carro (
   id_carro int primary key auto_increment,
   ds_marca                varchar(50),
   ds_modelo               varchar(50),
   nr_ano_fabricacao       int,
   nr_ano_versao           int,
   ds_cor                  varchar(50),
   qtd_disponivel          int,
   bt_disponivel           bool
);


create table tb_agendamento (
   id_agendamento int primary key auto_increment,
   id_funcionario          int,
   id_cliente              int,
   id_carro                int,
   ds_situacao             varchar(50),
   dt_agendamento          datetime,
   nr_avaliacao            int,
   FOREIGN key(id_funcionario) REFERENCES tb_funcionario(id_funcionario) on DELETE CASCADE,
   FOREIGN key (id_cliente) REFERENCES tb_cliente (id_cliente) on DELETE CASCADE,
   Foreign key (id_carro) references tb_carro (id_carro) on delete cascade
);

*/