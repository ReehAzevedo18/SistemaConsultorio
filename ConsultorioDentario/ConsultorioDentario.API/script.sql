select * from Endereco
insert into Endereco (logradouro, num, complemento, bairro, cidade) values ('Rua Silva Cardoso', 100, 'fundos', 'Bangu', 'Rio de Janeiro');
insert into Endereco (logradouro, num, complemento, bairro, cidade) values ('Rua Dias da Cruz', 8, 'apt 202', 'Meier', 'Rio de Janeiro');
insert into Endereco (logradouro, num, complemento, bairro, cidade) values ('Ab. Beira Mar ', 50, 'casa 302', 'Copacabana', 'Rio de Janeiro');
insert into Endereco (logradouro, num, complemento, bairro, cidade) values ('Estrada Doze de Janeiro', 500, 'casa 20', 'Niterói', 'Rio de Janeiro');


create table Paciente(
id_paciente int IDENTITY(1,1) primary key, 
Nome varchar(200) not null,
CPF varchar(15),
dt_nascimento varchar(10),
numCarteira varchar(6),
dt_cadastro varchar(10),
id_endereco int)


select * from Paciente
insert into Paciente (Nome, CPF, dt_nascimento, numCarteira, dt_cadastro, id_endereco) 
values ('Roger Alves', '395.850.897-93', '1980-07-22', '373645', '2020-02-05', 1)

insert into Paciente (Nome, CPF, dt_nascimento, numCarteira, dt_cadastro, id_endereco) 
values ('Eduarda Ribeiro', '936.306.587-17', '1960-05-30', '674545', '2020-10-23', 2)

select * from Dentista
insert into Dentista(Nome, CPF, matricula, id_endereco) 
values ('Dr. Paulo Azeredo', '499.993.221-07', '8322267889', 3)

insert into Dentista(Nome, CPF, matricula, id_endereco) 
values ('Dra. Vilma Carla', '002.592.143-61', '4728523191', 4)

select * from Procedimento
insert into Procedimento (Nome, duracao, valor)
values ('Implante Dentário', 180, '500.00')

insert into Procedimento (Nome, duracao, valor)
values ('Clareamento', 120, '1000.00')

insert into Procedimento (Nome, duracao, valor)
values ('Endodontia (tratamento de canal)', 120, '300.00')

select * from Consulta
insert into Consulta (dt_consulta, observacao, Dentistaid_dentista, Pacienteid_paciente, Procedimentoid_procedimento)
values ('2020-03-06', 'Primeira consulta', 1, 1, 1)

insert into Consulta (dt_consulta, observacao, Dentistaid_dentista, Pacienteid_paciente, Procedimentoid_procedimento)
values ('2020-11-15', 'Tratamento', 2, 2, 2)