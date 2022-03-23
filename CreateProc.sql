use biltiful ;

create procedure Inserir_Compra
	@ValorTotal numeric(7,2),
	@CNPJ_fornecedor varchar(14)
as
begin
	INSERT into Compra (ValorTotal,CNPJ_Fornecedor)
	values (@ValorTotal,@CNPJ_fornecedor)
end;

exec Inserir_Compra 555,'01376825000178';
			

Create Procedure Inserir_ItemCompra
	@ID_ItemCompra	numeric(5,0),
	@Quantidade		numeric(5,2),
	@ValorUnitario	 numeric(5,2),
	@TotalItem		numeric(5,2),
	@Id_Compra_IC	numeric(5,0),
	@ID_MPrima_IC varchar(6)
as
begin
	INSERT INTO ItemCompra
	VALUES (@ID_ItemCompra,@Quantidade,@ValorUnitario,@TotalItem,@Id_Compra_IC,@ID_MPrima_IC)
end;

Create Procedure Inserir_MPrima
	@Id				varchar(6),
	@Nome			nvarchar(30) 
as
begin
	INSERT INTO MPrima (Id,Nome)
	VALUES (@Id,@Nome)
end;

Create Procedure Inserir_Fornecedor
	@CNPJ			varchar(14),
	@RazaoSocial		nvarchar(50),
	@DataAbertura	date
as
begin
	Insert into fornecedor(CNPJ,RazaoSocial,DataAbertura)
	values (@CNPJ,@RazaoSocial,@DataAbertura)
end;

Create Procedure Inserir_ItemCompra
	@ID_ItemCompra	int,
	@Quantidade		numeric(5,2),
	@ValorUnitario	numeric(5,2),
	@TotalItem		numeric(6,2),
	@Id_Compra_IC	numeric(5,0),
	@Id_MPrima_IC	varchar(6)
as
begin
	Insert into ItemCompra
	values(@ID_ItemCompra,@Quantidade,@ValorUnitario,@TotalItem,@Id_Compra_IC,@Id_MPrima_IC)
end;



alter Procedure Inserir_Produto	
	@Nome			nvarchar(20),
	@ValorVenda		numeric(5,2)	
as
begin
	Insert into Produto (Nome,ValorVenda)
	values(@Nome,@ValorVenda)
end;

Create Procedure Inserir_Producao		
	@Quantidade				numeric(5,2),
	@CodigoBarras_Produto	varchar(12)
as
begin
	Insert into Producao(Quantidade,CodigoBarras_Produto)
	values(@Quantidade,@CodigoBarras_Produto)
end;

Create Procedure Inserir_Venda	
	@ValorTotal numeric(7,2),
	@CPF_Cliente varchar(11)
as
begin
	Insert into Venda(ValorTotal,CPF_Cliente)
	values(@ValorTotal,@CPF_Cliente)
end;

Create Procedure Inserir_Cliente
	@CPF				varchar(11),
	@Nome			nvarchar(50),
	@DataNascimento	date,
	@Sexo			char

as
begin
	Insert into Cliente(CPF,Nome,DataNascimento,Sexo)
	values(@CPF,@Nome,@DataNascimento,@Sexo)
end;

Create Procedure Inserir_Bloqueado
	@CNPJ_Fornecedor varchar(14)
as
begin
	Insert into Bloqueado
	values(@CNPJ_Fornecedor)
end;

Create Procedure Inserir_Risco
	@CPF_Cliente varchar(11)
as
begin
	Insert into Risco
	values(@CPF_Cliente )
end;

Create Procedure Inserir_ItemProducao
	@Id_Producao			numeric(5,0),
	@Id_MPrima			numeric(4,0),
	@QuantidadeMPrima	numeric(5,2)
as
begin
	Insert into ItemProducao
	values (@Id_Producao,@Id_MPrima,@QuantidadeMPrima)
end;

Create Procedure Inserir_ItemVenda
	@Id_ItemVenda			int,
	@Id_Venda				numeric(5,0),
	@CodigoBarras_Produto	varchar(12),
	@Quantidade				numeric(3,0),
	@TotalItem				numeric(6,2),
	@ValorUnitario			numeric(5,2)
as
begin
	Insert into ItemVenda
	values(@Id_ItemVenda,@Id_Venda,@CodigoBarras_Produto,@Quantidade,@TotalItem,@ValorUnitario)
end;