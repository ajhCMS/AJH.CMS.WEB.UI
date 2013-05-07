USE [DEMO]
GO
/****** Object:  StoredProcedure [ECOMMERCE].[GroupGetAll]    Script Date: 05/07/2013 01:32:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [ECOMMERCE].[GroupGetBYCOMBINATIONID]
	@P_COMBINATION_ID INT,
	@P_GROUP_PORTAL_ID int,
	@P_MODULE_ID INT,
	@P_ECO_LAN_LAN_ID INT
    
AS
BEGIN
	SET NOCOUNT ON;
	
		select
		G.[GROUP_ID],
		G.[GROUP_IS_COLOR_GROUP],
		G.[GROUP_IS_DELETED],
		G.[GROUP_PORTAL_ID],
		EL.[ECO_LAN_LAN_ID],
		EL.[ECO_LAN_NAME],
		EL.[ECO_LAN_NAME2]
		
		 FROM  [ECOMMERCE].[GROUP] as G
		 
		 LEFT OUTER JOIN
		   ECOMMERCE.ECOMMERCE_LANGUAGE AS EL
	 ON	
				EL.[ECO_LAN_OBJ_ID] = G.[GROUP_ID]
			AND
				EL.[ECO_LAN_MODULE_ID] = @P_MODULE_ID
			AND
				EL.[ECO_LAN_LAN_ID] = @P_ECO_LAN_LAN_ID
				
			WHERE G.[GROUP_IS_DELETED] = 0 and G.[GROUP_PORTAL_ID] =@P_GROUP_PORTAL_ID
			AND G.GROUP_ID IN(
						SELECT at.ATTRIBUTE_GROUP_ID 
								FROM [ECOMMERCE].[ATTRIBUTE] as at
								WHERE at.ATTRIBUTE_ID IN(
																 SELECT COMP_AT.ATTRIBUTE_ID
																 FROM [ECOMMERCE].[COMBINATION_ATTRIBUTE] as COMP_AT
																 WHERE COMP_AT.COMBINATION_ID = @P_COMBINATION_ID
																)							   
								)
						
END
