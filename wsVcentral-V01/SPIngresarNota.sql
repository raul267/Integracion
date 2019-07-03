
use db_vcentral;

drop procedure SPIngresarNota;


create procedure SPIngresarNota(
	@ano int, 
	@per int,
	@codramo varchar(50),
	@codsecc varchar(50),
	@codalu varchar(50),
	@nf numeric(3,1))
as
Begin
	declare @Vcodramo varchar(50);
	declare @Vnf numeric(3,1);
	declare @Vestado varchar(1);
	
	--Si ya lo cursó--
	if (0 < (select COUNT(codramo)
			from nota 
			group by codalu, codramo
			having (codalu = @codalu) and 
				   (codramo = @codramo)))
		begin
			--Si lo aprobó--
			if (@nf >= 4)
				begin
					--Si lo aprobó en la ocación anterior--
					if ('A' = 
						(select top 1 estado
						from nota
						where (codramo = @codramo) and (codalu = @codalu)
						order by nf desc))
						begin
							--si la nota nueva es mayor--
							if (@nf > 
								(select top 1 nf 
								 from nota
								 where (codramo = @codramo) and (codalu = @codalu)
								 order by nf desc))
								begin
								   delete from nota where codramo = @codramo and codalu =  @codalu;
								   insert into nota values(@ano, @per, @codramo,@codsecc, @codalu,@nf,'A');
								end
							--Si la nota vieja es mayor, no pasa nada--
						end
					--si no lo aprobó en la ocación anterior--
					else
						begin
							insert into nota values(@ano, @per, @codramo,@codsecc, @codalu,@nf,'S');
						end
				end
			--Si no lo aprobó
			else
				begin
					insert into nota values(@ano, @per, @codramo,@codsecc, @codalu,@nf,'R');
				end
			end
	--Si no lo ha cursado
	else
		begin
			--Si lo aprobó--
			if (@nf >= 4)
				begin
					insert into nota values(@ano, @per, @codramo,@codsecc, @codalu,@nf,'A');
				end
			--Si no lo aprobó
			else
				begin
					insert into nota values(@ano, @per, @codramo,@codsecc, @codalu,@nf,'R');
				end
			
		end
end

--Ejecución--
exec SPIngresarNota @ano= , @per= , @codramo = '', @codsecc= '' ,@codalu = '' ,@nf= ; 

--Ejemplo
exec SPIngresarNota @ano= 2019, @per= 2, @codramo = 'base01', @codsecc= '1' ,@codalu = '11944' ,@nf= 6.2; 