-- Step 3
if not exists( select 1 from SECURITY.FORM where FORM_CODE='/Admin/ECommerce/Customer/FrmManageCustomers.aspx')
begin
insert into SECURITY.FORM
(
FORM_NAME,
FORM_DESCRIPTION,
FORM_URL,
FORM_CODE,
FORM_MODULE_ID,
FORM_IS_DELETED
)
values
(
'Customers',
'Customers Manager',
'~/Admin/ECommerce/Customer/FrmManageCustomers.aspx',
'/Admin/ECommerce/Customer/FrmManageCustomers.aspx',
0,
0
)
end

go
declare @CodeID int;
select @CodeID=form.FORM_ID from SECURITY.FORM where FORM_CODE='/Admin/ECommerce/Customer/FrmManageCustomers.aspx'
if not exists(select 1 from SECURITY.FORM_ROLE where FORM_ROLE.FORM_ROLE_FORM_ID=@CodeID)
begin
insert into SECURITY.FORM_ROLE
(
 FORM_ROLE_FORM_ID, 
 FORM_ROLE_ROLE_ID, 
 FORM_ROLE_ACCESS_TYPE
)
values
(
@CodeID,
1,
1
)
end 