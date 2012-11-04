﻿CREATE PROCEDURE [ECOMMERCE].[FeatureGetAll]
	@P_MODULE_ID INT,
	@P_ECO_LAN_LAN_ID INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
			F.[FEATURE_ID],
			F.[FEATURE_IS_DELETED],
			F.[FEATURE_PORTAL_ID],
			EL.[ECO_LAN_LAN_ID],
			EL.[ECO_LAN_NAME],
			EL.[ECO_LAN_OBJ_ID]
	 FROM  [ECOMMERCE].[FEATURE] AS F
			LEFT OUTER JOIN
		   ECOMMERCE.ECOMMERCE_LANGUAGE AS EL
	 ON	
				EL.[ECO_LAN_OBJ_ID] = F.[FEATURE_ID]
			AND
				EL.[ECO_LAN_MODULE_ID] = @P_MODULE_ID
			AND
				EL.[ECO_LAN_LAN_ID] = @P_ECO_LAN_LAN_ID
		where
				F.[FEATURE_IS_DELETED] = 0
	END
