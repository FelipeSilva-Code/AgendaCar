
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
   nm_funcionario           varchar(100),
   ds_carteira_trabalho     varchar(11),
   ds_perfil                varchar(100),
   foreign key(id_login) references tb_login(id_login) on delete cascade
);

create table tb_cliente (
   id_cliente int primary key auto_increment,
   id_login                int,
   nm_cliente              varchar(100),
   ds_cnh                  varchar(11),                                                                                                 ,
   ds_cpf                  varchar(11),
   ds_telefone             varchar(15),
   dt_nascimento           datetime,
   foreign key(id_login) references tb_login(id_login) ondelete cascade
);

create table tb_carro (
   id_carro int primary key auto_increment,
   ds_marca                varchar(50),
   ds_modelo               varchar(50),
   nr_ano_fabricacao       int,
   nr_ano_versao           int,
   ds_cor                  varchar(50),
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
   FOREIGN key(id_funcionario) REFERENCES tb_funcionario(id_funcionario) onDELETE CASCADE,
   FOREIGN key (id_cliente) REFERENCES tb_cliente (id_cliente) on DELETE CASCADE,
   Foreign key (id_carro) references tb_carro (id_carro) on delete cascade
);

*/








































insert into tb_login (ds_cpf, ds_senha, ds_perfil, dt_ultimo_login)
values ("11111111111", "abc123", "Cliente", '2020-09-18');

insert into tb_login (ds_cpf, ds_senha, ds_perfil, dt_ultimo_login)
values ("20202020202", "fghj223", "Cliente", '2020-09-18');

insert into tb_login (ds_cpf, ds_senha, ds_perfil, dt_ultimo_login)
values ("55555555555", "123abc", "Funcionario", '2020-09-18');

insert into tb_cliente (id_login, nm_cliente, ds_cnh, ds_rg, ds_email, ds_telefone, bt_deficiente)
values (1, "José Silveiro", "12345678901", "123456789", "jose@gmail.com", "(11) 971333770", false);

insert into tb_cliente (id_login, nm_cliente, ds_cnh, ds_rg, ds_email, ds_telefone, bt_deficiente)
values (3, "Caio Silva", "12345678901", "123456789", "caio@gmail.com", "(11) 971333770", false);

insert into tb_funcionario (id_login, nm_funcionario, ds_carteira_trabalho, ds_perfil)
values (2, "Flavio Gabriel", "18932145672", "Vendedor");

insert into tb_carro (ds_marca, ds_modelo, nr_ano_fabricacao, nr_ano_versao, ds_cor, bt_carro_adapitado, bt_disponivel)
values ("Ford", "Focus", 2018, 2019, "Amarelo", false, true);

insert into tb_carro (ds_marca, ds_modelo, nr_ano_fabricacao, nr_ano_versao, ds_cor, bt_carro_adapitado, bt_disponivel)
values ("Fiat", "Uno", 2011, 2011, "Preto", false, true);

insert into tb_agendamento (id_funcionario, id_cliente, id_carro, ds_situacao, dt_agendamento, nr_avaliacao)
values (1, 1, 1, "Aprovado", '2020-09-21 10:00:00', 3);

insert into tb_agendamento (id_funcionario, id_cliente, id_carro, ds_situacao, dt_agendamento, nr_avaliacao)
values (1, 1, 2, "Aprovado", '2020-09-21 11:30:00', 3);

insert into tb_agendamento (id_funcionario, id_cliente, id_carro, ds_situacao, dt_agendamento, nr_avaliacao)
values (1, 1, 2, "Aprovado", '2020-09-22 13:30:00', 0);

insert into tb_agendamento (id_funcionario, id_cliente, id_carro, ds_situacao, dt_agendamento, nr_avaliacao)
values (1, 1, 2, "Não compareceu", '2020-09-20  15:20:00', 0);

insert into tb_agendamento (id_funcionario, id_cliente, id_carro, ds_situacao, dt_agendamento, nr_avaliacao)
values (1, 1, 2, "Aprovado", '2020-09-23  15:20:00', 0);

insert into tb_agendamento (id_funcionario, id_cliente, id_carro, ds_situacao, dt_agendamento, nr_avaliacao)
values (1, 1, 2, "Pendente", '2020-09-23 14:00:00', 0);

insert into tb_agendamento (id_funcionario, id_cliente, id_carro, ds_situacao, dt_agendamento, nr_avaliacao)
values (1, 1, 1, "Não compareceu", '2020-09-21 13:30:00', 0);

insert into tb_agendamento (id_funcionario, id_cliente, id_carro, ds_situacao, dt_agendamento, nr_avaliacao)
values (1, 1, 1, "Não compareceu", '2020-09-21 13:30:00', 0);

insert into tb_agendamento (id_funcionario, id_cliente, id_carro, ds_situacao, dt_agendamento, nr_avaliacao)
values (1, 1, 1, "Concluido", '2020-09-19 14:00:00', 0);

insert into tb_agendamento (id_funcionario, id_cliente, id_carro, ds_situacao, dt_agendamento, nr_avaliacao)
values (1, 1, 2, "Concluido", '2020-09-19 15:20:00', 0);
