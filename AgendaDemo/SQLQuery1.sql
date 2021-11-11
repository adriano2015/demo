
create table contatosAgenda(
 codContato integer identity (1,1) not null primary key, 
 NomeContato varchar(39),
 EnderecoContato varchar(39),
 TelefonesContato varchar(39),
 CelularContato varchar(39),
 EmailContato varchar(39),
 LinkedinContato varchar(39),
 CepContato varchar(8),
 PesquisaContato varchar (39),
 DataNascimentoContato date,
 UFContato varchar (2),
 CidadeContato varchar (39)
)
go







