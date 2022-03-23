use biltiful ;
create table Compra
(
Id				numeric(5,0) identity(1,1) not null,
DataCompra		date not null DEFAULT GETDATE(),
ValorTotal		numeric(7,2) not null,
CNPJ_fornecedor varchar(14)  not null

constraint PK_Compra primary key(id),
constraint FK_Fornecedor_Compra foreign key(CNPJ_fornecedor) references Fornecedor(CNPJ)

);

create table MPrima
(
Id				varchar(6)	 not null,
Nome			nvarchar(30) not null,
UltimaCompra	date not null DEFAULT GETDATE(),
DataDadastro	date not null DEFAULT GETDATE(),
Situacao		char not null DEFAULT '1'

constraint PK_MPrima primary key(Id)
);


create table fornecedor
(
CNPJ			varchar(14) not null,
RazaoSocial		nvarchar(50) not null,
DataAbertura	date not null,
UltimaCompra	date not null DEFAULT GETDATE(),
DataDadastro	date not null DEFAULT GETDATE(),
Situacao		char not null DEFAULT '1'

constraint PK_Fornecedor primary key(CNPJ)
);

create table ItemCompra
(
ID_ItemCompra	int not null,
Quantidade		numeric(5,2) not null,
ValorUnitario	numeric(5,2) not null,
TotalItem		numeric(6,2) not null,
Id_Compra_IC	numeric(5,0) not null,
Id_MPrima_IC	varchar(6) not null

constraint PK_Id_Compra_IC	primary key(Id_Compra_IC,ID_ItemCompra,Id_MPrima_IC),
constraint FK_Id_Compra_IC	foreign key(Id_Compra_IC) references Compra(Id),
constraint FK_Id_MPrima_IC	foreign key(Id_MPrima_IC) references MPrima(Id)
);
SELECT Id ,CNPJ_fornecedor, DataCompra, ValorTotal FROM dbo.Compra WHERE CNPJ_fornecedor = '01376825000178'";
Create table Produto
(
CodigoBarras	Numeric(12) IDENTITY(789661700001, 1) not null,
Nome			nvarchar(20) not null,
ValorVenda		numeric(5,2) not null,
UltimaVenda		date not null DEFAULT GETDATE(),
DataCadastro	date DEFAULT GETDATE(),
Situacao		char not null DEFAULT '1'

constraint PK_Produto primary key (CodigoBarras)
);

create table Producao
(
Id						numeric(5,0) identity not null,
DataProducao			date not null DEFAULT GETDATE(),
Quantidade				numeric(5,2) not null,
CodigoBarras_Produto	Numeric(12) not null

constraint PK_Producao primary key(Id),
constraint FK_Produto_Producao foreign key (CodigoBarras_Produto) references Produto(CodigoBarras)
);

create table Venda
(
Id			numeric(5,0) identity not null,
DataVenda	date not null default getdate(),
ValorTotal	numeric(7,2) not null,
CPF_Cliente varchar(11) not null

constraint PK_Venda			primary key(Id),
constraint FK_Cliente_Venda foreign key(CPF_Cliente) references Cliente(CPF)
);

create table Cliente
(
CPF				varchar(11) not null,
Nome			nvarchar(50) not null,
DataNascimento	date not null,
Sexo			char not null,
UltimaCompra	date not null default getdate(),
DataCadastro	date not null default getdate(),
Situacao		char not null default '1'

constraint PK_Cliente primary key(CPF)
);

create table Bloqueado
(
CNPJ_Fornecedor varchar(14) not null

constraint PK_Bloqueado				primary key(CNPJ_Fornecedor),
constraint FK_Bloqueado_Fornecedor  foreign key (CNPJ_Fornecedor) references Fornecedor(CNPJ)
);

create table Risco
(
CPF_Cliente varchar(11) not null

constraint PK_Risco			primary key (CPF_Cliente),
constraint FK_Risco_Cliente foreign key (CPF_Cliente) references Cliente(CPF)
);

create table ItemProducao
(
Id_Producao			numeric(5,0) not null,
Id_MPrima			numeric(4,0) not null,
QuantidadeMPrima	numeric(5,2) not null

constraint PK_Item_Producao primary key(id_producao),
constraint FK_Item_Producao foreign key(id_producao) references producao(id)
);

create table ItemVenda
(
Id_ItemVenda			int  not null,
Id_Venda				numeric(5,0) not null,
CodigoBarras_Produto	Numeric(12) not null,
Quantidade				numeric(3,0) not null,
TotalItem				numeric(6,2) not null,
ValorUnitario			numeric(5,2) not null

constraint PK_Item_Venda primary key (Id_Venda,Id_ItemVenda,CodigoBarras_Produto),
constraint FK_Venda_IV foreign key (Id_Venda) references Venda(Id),
constraint FK_Cod_Barras_IV foreign key (CodigoBarras_Produto) references Produto(CodigoBarras)
);