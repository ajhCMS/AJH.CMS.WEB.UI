USE [DEMO]
GO
/****** Object:  StoredProcedure [ECOMMERCE].[AttributeGetByCombinationID]    Script Date: 05/07/2013 01:21:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  PROCEDURE [ECOMMERCE].[AttributeGetByCombinationGRPID]
	@P_COMBINATION_ID int,
	@P_GROUP_ID int,
	@P_MODULE_ID INT,
	@P_ECO_LAN_LAN_ID INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
			A.[ATTRIBUTE_ID],
			A.[ATTRIBUTE_GROUP_ID],
			A.[ATTRIBUTE_PORTAL_ID],
			A.[ATTRIBUTE_IS_DELETED],
			EL.[ECO_LAN_LAN_ID],
			EL.[ECO_LAN_NAME],
			EL.[ECO_LAN_OBJ_ID]
	 FROM  [ECOMMERCE].[ATTRIBUTE] AS A
			INNER JOIN 
		   [ECOMMERCE].[COMBINATION_ATTRIBUTE] AS CA
	 ON   
	           CA.ATTRIBUTE_ID = A.[ATTRIBUTE_ID]
	        AND
	           CA.COMBINATION_ID = @P_COMBINATION_ID
			LEFT OUTER JOIN
		   ECOMMERCE.ECOMMERCE_LANGUAGE AS EL
	 ON	
				EL.[ECO_LAN_OBJ_ID] = A.[ATTRIBUTE_ID]
			AND
				EL.[ECO_LAN_MODULE_ID] = @P_MODULE_ID
			AND
				EL.[ECO_LAN_LAN_ID] = @P_ECO_LAN_LAN_ID
			WHERE 
				A.[ATTRIBUTE_GROUP_ID] = @P_GROUP_ID
	END
