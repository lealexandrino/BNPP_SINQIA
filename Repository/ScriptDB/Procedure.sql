CREATE PROCEDURE [dbo].[GetMovimentosManuais]
AS
    SET NOCOUNT ON;
    select m.DAT_MES, M.DAT_ANO, m.COD_PRODUTO, p.DES_PRODUTO, m.NUM_LANCAMENTO, m.DES_DESCRICAO, m.VAL_VALOR, m.COD_COSIF, m.COD_USUARIOS, m.DAT_MOVIMENTO  from movimento_manual m
	join produto_cosif pc on pc.COD_COSIF = m.COD_COSIF
	join produto p on p.COD_PRODUTO  = m.COD_PRODUTO
	ORDER BY 1, 2, 5;
RETURN
GO